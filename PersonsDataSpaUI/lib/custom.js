/* Scroll to Top */

$(".totop").hide();

$(function(){
	$(window).scroll(function(){
	  if ($(this).scrollTop()>100)
	  {
		$('.totop').fadeIn();
	  } 
	  else
	  {
		$('.totop').fadeOut();
	  }
	});
});



  