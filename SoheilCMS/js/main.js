"use strict";
jQuery(document).ready(function() {
	//menu
	if (jQuery().superfish) {
		jQuery('ul.sf-menu').superfish({
			delay:       700,
			animation:   {opacity:'show',height:'show'},
			//animation:   {opacity:'show'},
			animationOut: {opacity: 'hide'},
			speed:       'fast',
			disableHI:   false,
			cssArrows:   false,
			autoArrows:  true
		});
	}

	//toTop
	if (jQuery().UItoTop) {
        jQuery().UItoTop({ easingType: 'easeOutQuart' });
    }

    //horizontal accordion
    if (jQuery().elastislide) {
	    jQuery('#horizontal_slider').elastislide({
	        imageW : 360,
	        border : 0,
	        minItems : 1,
	        margin : 30
	    });
	}

	//parallax
	if (jQuery().parallax) {
		// jQuery('#testimonials').parallax("50%", 0.4);
		// jQuery('#tweets').parallax("50%", 0.5);
	}
	
	//funny text
	if (jQuery().funnyText) {
		jQuery('.funnyText').funnyText({
			speed: 700,
			borderColor: 'transparent',
			activeColor: '#abce6c',
			color: '#fff',
			fontSize: '1.4em',
			direction: 'both'
		});
	}

    //prettyPhoto
    if (jQuery().prettyPhoto) {
	   	jQuery("a[rel^='prettyPhoto']").prettyPhoto({
			theme: 'facebook' /* light_rounded / dark_rounded / light_square / dark_square / facebook / pp_default*/
	  	});
	}

   	//carousel
   	if (jQuery().carousel) {
		jQuery('.carousel').carousel();
	}

	//owl caousel
	if (jQuery().owlCarousel) {
	    jQuery(".owl-carousel").owlCarousel({
	    	navigation : true,
	    	navigationText : false,
	    	pagination : false
	    });
	}
    
    //nice scroll
	if (jQuery().niceScroll) {
    	// jQuery("html").niceScroll({
    	// 	cursorcolor: '#464646',
    	// 	cursorborder: 'none',
    	// 	cursorborderradius: '0',
    	// 	cursorwidth: '8px'
    	// });
	}

	//bx slider
	if (jQuery().bxSlider) {
		jQuery('.bxslider').bxSlider({
			auto: true,
			controls: false,
			pager: false,
		  	mode: 'fade'
		});
	}

	//timeline
	if (jQuery().timelinr) {
		if(jQuery('#timeline').length) {
			jQuery('#timeline').timelinr({
				orientation: 	'vertical',
				issuesSpeed: 	300,
				datesSpeed: 	100,
				arrowKeys: 		'true',
			});
		}
	}

	//single page localscroll and scrollspy
	var navHeight = jQuery('#header').outerHeight(true) + 40;
	jQuery('body').scrollspy({
		target: '.mainmenu_wrap',
		offset: navHeight
	});
	if (jQuery().localScroll) {
		jQuery('#mainmenu, #land').localScroll({
			duration:1900,
			easing:'easeOutQuart',
			offset: 0
		});
		
	}

	//portfolio and horizontal slider animation
	jQuery('.portfolio_item_image .portfolio_links').css({opacity: 0});
	jQuery('.isotope-item, .horizontal_slider_introimg').hover(
	 	function() {
			jQuery( this ).find('.portfolio_item_image .portfolio_links').stop().animate({ opacity: 1}, 500, 'easeOutExpo').find('.p-view').toggleClass('moveFromLeft').end().find('.p-link').toggleClass('moveFromRight');
		}, function() {
			jQuery( this ).find('.portfolio_item_image .portfolio_links').stop().animate({ opacity: 0}, 300, 'easeOutExpo').find('.p-view').toggleClass('moveFromLeft').end().find('.p-link').toggleClass('moveFromRight');
		}
	);

	//teaser style5 animation
	jQuery('.single_teaser.icons.style5').hover(
	 	function() {
			jQuery( this ).find('i').addClass('moveFromLeft').end().find('h3').addClass('moveFromRight').end().find('p').addClass('moveFromBottom');
		}, function() {
			jQuery( this ).find('i').removeClass('moveFromLeft').end().find('h3').removeClass('moveFromRight').end().find('p').removeClass('moveFromBottom');
		}
	);


	//twitter
	//slide tweets
	jQuery('#tweets .twitter').bind('loaded', function(){
		jQuery(this).addClass('flexslider').find('ul').addClass('slides');
	});
	if (jQuery().tweet) {
		jQuery('.twitter').tweet({
			modpath: "./twitter/",
		    count: 2,
		    avatar_size: 48,
		    loading_text: 'loading twitter feed...',
		    join_text: 'auto',
		    username: 'ThemeForest', 
		    template: "{avatar}{time}{join}<span class=\"tweet_text\">{tweet_text}</span>"
		});
	}

});

jQuery(window).load(function(){
	
	setTimeout(function(){
		jQuery('.progress-bar').addClass('stretchRight');
	}, 600);

	//stick header to top
	if (jQuery().sticky) {
	    jQuery("#header").sticky({ 
	    		topSpacing: 0,
	    		scrollBeforeStick: 10
	    	},
	    	function(){ 
	    		jQuery("#header").stop().animate({opacity:0}, 0).delay(500).stop().animate({opacity:1}, 1000);
	    	},
	       	function(){ 
	    		jQuery("#header").stop().animate({opacity:0}, 0).delay(50).stop().animate({opacity:1}, 2000);
	    	}
	    );
	}
	

	if (jQuery().flexslider) {
		var $mainSlider = jQuery('#mainslider');
		jQuery(".flexslider").flexslider({
			animation: "fade",
			useCSS: true,
			controlNav: true,   
			//animationLoop: false,
			smoothHeight: true,
			slideshowSpeed:5000,
			animationSpeed:800,
			after :function( slider ){
			  	//bg-color1 - class for #mainslider
			  	var currentClass = $mainSlider.find('.flex-active-slide').attr('data-bg');
			  	$mainSlider.attr('class', currentClass);
			}
		});
	}

	jQuery('body').delay(1000).scrollspy('refresh');


	//preloader
	jQuery(".preloaderimg").fadeOut();
	jQuery(".preloader").delay(200).fadeOut("slow").delay(200, function(){
		jQuery(this).remove();
	});

	//fractionslider
	if (jQuery().fractionSlider) {
		var $mainSlider = jQuery('#mainslider');
		jQuery('.slider').fractionSlider({
			'fullWidth': 			true,
			'controls': 			false, 
			'pager': 				true,
			'responsive': 			true,
			'dimensions': 			"1170,800",
		    'increase': 			false,
			'pauseOnHover': 		false,
			'slideEndAnimation': 	true,
			'slideChangeCallback' :function(el, currentSlide, lastSlide, step ){
			  /* paramters:
			  el = the slider element
			  currentSlide = the current slide (in case of nextSlideCallback etc. its the new slide)
			  lastSlide = the last/previouse slide
			  step = the current step
			  */
			  	//bg-color1 - class for #mainslider
			  var currentClass = $mainSlider.attr('class').toString();
			  var currentClassNum = currentClass.substring(8);
			  currentClassNum++;
			  if (currentClassNum > 3) {
			  	currentClassNum = 1;
			  };
			  $mainSlider.attr('class', 'bg-color' + currentClassNum);
			}
		});
	}



	//flickr
	// use http://idgettr.com/ to find your ID
	if (jQuery().jflickrfeed) {
		jQuery("#flickr").jflickrfeed({
			flickrbase: "http://api.flickr.com/services/feeds/",
			limit: 8,
			qstrings: {
				id: "37671286@N07"
			},
			itemTemplate: '<a href="{{image_b}}" rel="prettyPhoto[pp_gal]"><li><img alt="{{title}}" src="{{image_s}}" /></li></a>'
		}, function(data) {
			jQuery("#flickr a").prettyPhoto({
				theme: 'facebook'
	   		});
	   		jQuery("#flickr li").hover(function () {						 
			   jQuery(this).find("img").stop().animate({ opacity: 0.5 }, 200);
		    }, function() {
			   jQuery(this).find("img").stop().animate({ opacity: 1.0 }, 400);
		    });
		});
	}

	//animation to elements
	var windowHeight = jQuery(window).height();
	jQuery('.to_fade, .block-header, .block-header + p').each(function(){
	var imagePos = jQuery(this).offset().top;
	var topOfWindow = jQuery(window).scrollTop();
		if (imagePos < topOfWindow+windowHeight-100) {
			jQuery(this).addClass("animated fadeInUp");
		}
	});

	jQuery('.to_slide_left').each(function(){
	var imagePos = jQuery(this).offset().top;

	var topOfWindow = jQuery(window).scrollTop();
		if (imagePos < topOfWindow+windowHeight-100) {
			jQuery(this).addClass("animated fadeInLeft");
		}
	});

	jQuery('.to_slide_right').each(function(){
	var imagePos = jQuery(this).offset().top;

	var topOfWindow = jQuery(window).scrollTop();
		if (imagePos < topOfWindow+windowHeight-100) {
			jQuery(this).addClass("animated fadeInRight");
		}
	});

});

jQuery(window).resize(function(){
	jQuery("#header").sticky('update');
	jQuery('body').scrollspy('refresh');

});

jQuery(window).scroll(function() {

	//circle progress bar
	if (jQuery().easyPieChart) {
		var count = 0 ;
		var colors = ['#fbcf61', '#e6557c', '#00c1e4'];
		jQuery('.chart').each(function(){

				
			var imagePos = jQuery(this).offset().top;
			var topOfWindow = jQuery(window).scrollTop();
			if (imagePos < topOfWindow+600) {

				jQuery(this).easyPieChart({
			        barColor: colors[count],
					trackColor: '#f0f0f0',
					scaleColor: false,
					scaleLength: false,
					lineCap: 'butt',
					lineWidth: 30,
					size: 230,
					rotate: 0,
					animate: 2000,
					onStep: function(from, to, percent) {
							jQuery(this.el).find('.percent').text(Math.round(percent));
						}
			    });
			}

			count++;
			if (count >= colors.length) { count = 0};
		});
	}

	//animation to elements
	var windowHeight = jQuery(window).height();
	jQuery('.to_fade, .block-header, .block-header + p').each(function(){
	var imagePos = jQuery(this).offset().top;
	var topOfWindow = jQuery(window).scrollTop();
		if (imagePos < topOfWindow+windowHeight-100) {
			jQuery(this).addClass("animated fadeInUp");
		}
	});

	jQuery('.to_slide_left').each(function(){
	var imagePos = jQuery(this).offset().top;

	var topOfWindow = jQuery(window).scrollTop();
		if (imagePos < topOfWindow+windowHeight-100) {
			jQuery(this).addClass("animated fadeInLeft");
		}
	});

	jQuery('.to_slide_right').each(function(){
	var imagePos = jQuery(this).offset().top;

	var topOfWindow = jQuery(window).scrollTop();
		if (imagePos < topOfWindow+windowHeight-100) {
			jQuery(this).addClass("animated fadeInRight");
		}
	});

});