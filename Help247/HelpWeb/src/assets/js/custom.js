$(document).ready(function ($) {
  ScrollOut({
    targets: ".fades",
    threshold: 0.5,
    once: true,
  });

  $(".menu ul li:has(ul)").addClass("has-child");
  $(".menu ul li:has(ul)").prepend('<span class="nav-click" />');
  $("#menu-toggle").click(function () {
    $(".menu > ul").toggleClass("open-menu");
  });

  $(".nav-click").click(function () {
    $(this).parent().find("ul").toggleClass("subshow");
    $(this).toggleClass("arrowup");
  });

  $(".rate-list").simpleLoadMore({
    item: ".media",
    count: 3,
    btnHTML: '<a href="#" class="load-more__btn">Read More Reviews</a>',
  });

  $("#menu-toggle").click(function () {
    $(this).toggleClass("open");
  });

  $(".mobifilter").click(function () {
    $(".hire-sidebar").toggleClass("open");
    $(this).toggleClass("open");
  });

  $(".mobilemenu").on("click", function () {
    $(".animated-icon1").toggleClass("open");
    $(".menu > ul").toggleClass("open-menu");
    $("body").toggleClass("fxbg");
  });

  $(".mobiledrop").click(function () {
    $(this).parent().toggleClass("open");
    // $(this).toggleClass('arrowup');
  });

  var starRatingControl = new StarRating(".star-rating");

  $(".fieldcheck").click(function () {
    if ($(this).prop("checked") == true) {
      $(".fieldcheck").each(function () {
        $(this).prop("checked", false);
      });
      $(this).prop("checked", true);
    }
  });

  // $("#from-datepicker").datepicker();
  // $("#to-datepicker").datepicker();

  $(function () {
    $(document).scroll(function () {
      var $nav = $(".header-wrap");
      $nav.toggleClass("scrolled", $(this).scrollTop() > $nav.height());
    });

    // if ($('#toptech').length > 0) {
    //     $('#toptech').owlCarousel({
    //         loop: true,
    //         margin: 20,
    //         nav: true,
    //         dots: false,
    //         items: 3,
    //         responsive: {
    //             0: {
    //                 items: 1,
    //                 nav: false,
    //                 dots: true,
    //             },
    //             600: {
    //                 items: 1
    //             },
    //             768: {
    //                 items: 2
    //             },
    //             1000: {
    //                 items: 3
    //             }
    //         }
    //     });
    // }

    // if ($('.hmbanner').length > 0) {
    //     $('.hmbanner').owlCarousel({
    //         loop: true,
    //         margin: 0,
    //         nav: true,
    //         dots: false,
    //         items: 1,
    //     });
    // }

    // if ($('#hmtoptech').length > 0) {
    // $('#hmtoptech').owlCarousel({
    //     loop: true,
    //     margin: 30,
    //     nav: true,
    //     dots: false,
    //     items: 4,
    //     responsive: {
    //         0: {
    //             items: 1
    //         },
    //         600: {
    //             items: 1
    //         },
    //         768: {
    //             items: 3
    //         },
    //         1024: {
    //             items: 4
    //         }
    //     }
    // });
    // }

    // $(".play-1").yu2fvl();

    // var flag = 1;
    // $(window).scroll(function () {
    //     if (flag == 1) {
    //         if ($(this).scrollTop() > 800) {
    //             $('.number').easy_number_animate({
    //                 start_value: 0,
    //                 end_value: 2650,
    //                 duration: 3000,
    //                 delimiter: ''
    //             });
    //             $('.number2').easy_number_animate({
    //                 start_value: 0,
    //                 end_value: 790,
    //                 duration: 3000
    //             });
    //             $('.number3').easy_number_animate({
    //                 start_value: 0,
    //                 end_value: 650,
    //                 duration: 3000
    //             });
    //             $('.number4').easy_number_animate({
    //                 start_value: 0,
    //                 end_value: 210,
    //                 duration: 3000
    //             });

    //             flag = 0;
    //         } else { }
    //     }
    // });

    // var flag2 = 1;
    // if (flag2 == 1) {

    //     $('.job-number1').easy_number_animate({
    //         start_value: 0,
    //         end_value: 16,
    //         duration: 1000,
    //         delimiter: ''
    //     });
    //     $('.job-number2').easy_number_animate({
    //         start_value: 0,
    //         end_value: 13,
    //         duration: 1000
    //     });
    //     $('.job-number3').easy_number_animate({
    //         start_value: 0,
    //         end_value: 2,
    //         duration: 1000
    //     });
    //     $('.job-number4').easy_number_animate({
    //         start_value: 0,
    //         end_value: 11,
    //         duration: 1000
    //     });
    //     flag2 = 0;

    // }
  });
});
