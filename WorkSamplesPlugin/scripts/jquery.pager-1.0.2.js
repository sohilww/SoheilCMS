/*
 * MVC AJAX Pager JavaScript Library v1.0.2
 * http://kitsula.com/MvcAjaxPager
 *
 * Copyright 2012-2014 Igor Kitsula
 * Released under the MIT license
 * http://kitsula.com/MvcAjaxPager/license
 *
 * Date:  Dec 05 2012
 */
 
(function ($) {
	$.fn.pager = function (options) {
		//Default options
		var $options = {
			pageUrlParameter: 'page'
		};
		//Override default options
		$.extend($options, options);
		//history path: #/page/
		var path = '#/' + $options.pageUrlParameter + '/';
		//Set root default path: #/page/1
		if (this.length > 0) {
			Path.root(path + '1');
		};

		//Function selector
		var $selector = this.selector;
		var $selectors = $selector.split(',');
		//Bind click event handler for page links
		$($selectors).each(function (inx, selector) {
			$(document.body).on('click', selector + ' [data-page]', function () {
				var $this = $(this);
				if (typeof ($this.data('page')) != 'undefined') {
					window.location.href = location.pathname + path + $this.data('page');
				}
				return false;
			});
		});

		//Convert text function into code
		function getFunction(code, argNames) {
			var fn = window, parts = (code || "").split(".");
			while (fn && parts.length) {
				fn = fn[parts.shift()];
			}
			if (typeof (fn) === "function") {
				return fn;
			}
			argNames.push(code);
			return Function.constructor.apply(null, argNames);
		}

		//return set for forward jQuery chain
		return this.each(function (index, element) {
			//Setup anchor handler inside pagination wrapper
			if (typeof (Path.routes.defined[path + ':page']) == 'undefined') {
				Path.map(path + ':page')
					.enter(function () {
						var $element = $($selector).first();
						var currentPage = Path.routes.defined[path + ':page'].params['page'];
						if ($element.data('current') == currentPage) {
							return false;
						};
					})
					.to(function () {
						var pageNum = Path.routes.defined[path + ':page'].params['page'];
						var actionUrl = decodeURIComponent($($selector).data('action')).replace('#', pageNum);
						$.ajax({
							url: actionUrl,
							beforeSend: function (xhr) {
								var result = getFunction(element.getAttribute("data-ajax-begin"), ["xhr"]).apply(this, arguments);
								return result;
							},
							complete: function () {
								getFunction(element.getAttribute("data-ajax-complete"), ["xhr", "status"]).apply(this, arguments);
							},
							success: function (data, status, xhr) {
								$('#' + $(element).data('updatetargetid')).html(data);
								$("html, body").animate({ scrollTop: 0 }, "slow");
								getFunction(element.getAttribute("data-ajax-success"), ["data", "status", "xhr"]).apply(this, arguments);
							},
							error: getFunction(element.getAttribute("data-ajax-failure"), ["xhr", "status", "error"])
						});
					});
				Path.listen();
			}
		});
	};
} (jQuery));
