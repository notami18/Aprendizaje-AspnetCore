// Site.js
(function () {
    //let ele = $("#username");
    //ele.text("Carlos Andres");

    //var main = $("#main");

    //main.on("mouseenter",  function () {
    //    main.style = "backgroundColor : #888;";
    //});

    //main.on("mouseleave", function () {
    //    main.style = "";
    //});

    //var menuItems = $("ul.menu li a");

    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});

    var $sidebarAndWrapper = $("#sidebar, #wrapper");

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(this).text("Aparece Sidebar");
        } else {
            $(this).text("Desaparece Sidebar");
        }
    });

})();
