$(document).ready(function(){
	$('#nav').slicknav();
	$("#responsiv-videos").fitVids();
});

    $(function () {
        // Remove Search if user Resets Form or hits Escape!
		$('body, .navbar-collapse form[role="search"] button[type="reset"]').on('click keyup', function(event) {
			console.log(event.currentTarget);
			if (event.which == 27 && $('.navbar-collapse form[role="search"]').hasClass('active') ||
				$(event.currentTarget).attr('type') == 'reset') {
				closeSearch();
			}
		});

		function closeSearch() {
            var $form = $('.navbar-collapse form[role="search"].active')
    		$form.find('input').val('');
			$form.removeClass('active');
		}

		// Show Search if form is not active // event.preventDefault() is important, this prevents the form from submitting
		$(document).on('click', '.navbar-collapse form[role="search"]:not(.active) button[type="submit"]', function(event) {
			event.preventDefault();
			var $form = $(this).closest('form'),
				$input = $form.find('input');
			$form.addClass('active');
			$input.focus();

		});
		// ONLY FOR DEMO // Please use $('form').submit(function(event)) to track from submission
		// if your form is ajax remember to call `closeSearch()` to close the search container
		$(document).on('click', '.navbar-collapse form[role="search"].active button[type="submit"]', function(event) {
			event.preventDefault();
			var $form = $(this).closest('form'),
				$input = $form.find('input');
			$('#showSearchTerm').text($input.val());
            closeSearch()
		});
    });


$(document).ready(function(){
	$("#button").mouseenter(function(){
		$("#button").animate({
	        left: '250px',
	        height: '20px',
	        width: '120px'
    	});
	});
	$("#button").mouseleave(function(){
        $("#button").animate({
	        left: '50px',
	        opacity: '0.5',
	        height: '20px',
	        width: '20px',
	        color: '#000000',
	        overflow: 'hidden'
    	});
    });
});


$(document).ready(function(){
	$("#btnid").click(function(){
		$("#input").animate({
			left: '250px',
	        height: '20px',
	        width: '120px',
	        border: '1px solid black'
		});
	});
});

$(document).ready(function(){
	$("#hideicone1").click(function(){
		$("#searc").show();
	});
});