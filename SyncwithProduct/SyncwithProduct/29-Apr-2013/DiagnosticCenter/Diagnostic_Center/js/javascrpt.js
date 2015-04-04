// JavaScript Document

$(document).ready(function () {

		//loop through all the children in #items
		//save title value to a span and then remove the value of the title to avoid tooltips
		$('#items .item').each(function () {
			title = $(this).attr('title');
			$(this).append('<span class="caption">' + title + '</span>');	
			$(this).attr('title','');
		});

		$('#items .item').hover(
			function () {
				//set the opacity of all siblings
				$(this).siblings().css({'opacity': '0.3'});	
				
				//set the opacity of current item to full, and add the effect class
				$(this).css({'opacity': '1.0'}).addClass('effect');
				
				//show the caption
				$(this).children('.caption').show();	
			},
			function () {
				//hide the caption
				$(this).children('.caption').hide();		
			}
		);
		
		$('#items').mouseleave(function () {
			//reset all the opacity to full and remove effect class
			$(this).children().fadeTo('100', '1.0').removeClass('effect');		
		});
		
	});
	