// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    let activePage = localStorage.getItem("activePage");

    if (activePage) {
        $(".nav-item").removeClass("active");
        $(`.nav-item a[href='${activePage}']`).parent().addClass("active");
    }

    $(".nav-item a").click(function () {
        $(".nav-item").removeClass("active");
        $(this).parent().addClass("active");

        localStorage.setItem("activePage", $(this).attr("href"));
    });
});
