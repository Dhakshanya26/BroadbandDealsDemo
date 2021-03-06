﻿
function setUpSideFilters() {
    var mainContent = $('.cd-main-content'),
        header = $('.cd-main-header'),
        sidebar = $('.cd-side-nav'),
        sidebarTrigger = $('.cd-nav-trigger'),
        topNavigation = $('.cd-top-nav');
    var resizing = false;
    moveNavigation();
    $(window).on('resize', function () {
        if (!resizing) {
            (!window.requestAnimationFrame) ? setTimeout(moveNavigation, 300) : window.requestAnimationFrame(moveNavigation);
            resizing = true;
        }
    });
    var scrolling = false;
    checkScrollbarPosition();
    $(window).on('scroll', function () {
        if (!scrolling) {
            (!window.requestAnimationFrame) ? setTimeout(checkScrollbarPosition, 300) : window.requestAnimationFrame(checkScrollbarPosition);
            scrolling = true;
        }
    });
    sidebarTrigger.on('click', function (event) {
        event.preventDefault();
        $([sidebar, sidebarTrigger]).toggleClass('nav-is-visible');
    });

    function checkMQ() {
        return window.getComputedStyle(document.querySelector('.cd-main-content'), '::before').getPropertyValue('content').replace(/'/g, "").replace(/"/g, "");
    }

    function moveNavigation() {
        var mq = checkMQ();
        if (mq == 'mobile' && topNavigation.parents('.cd-side-nav').length == 0) {
            detachElements();
            topNavigation.appendTo(sidebar);
        } else if ((mq == 'tablet' || mq == 'desktop') && topNavigation.parents('.cd-side-nav').length > 0) {
            detachElements();
            topNavigation.appendTo(header.find('.cd-nav'));
        }
        checkSelected(mq);
        resizing = false;
    }

    function detachElements() {
        topNavigation.detach();
    }

    function checkSelected(mq) {
        if (mq == 'desktop') $('.has-children.selected').removeClass('selected');
    }

    function checkScrollbarPosition() {
        var mq = checkMQ();
        if (mq != 'mobile') {
            var sidebarHeight = sidebar.outerHeight(),
                windowHeight = $(window).height(),
                mainContentHeight = mainContent.outerHeight(),
                scrollTop = $(window).scrollTop();
            ((scrollTop + windowHeight > sidebarHeight) && (mainContentHeight - sidebarHeight != 0)) ? sidebar.addClass('is-fixed').css('bottom', 0) : sidebar.removeClass('is-fixed').attr('style', '');
        }
        scrolling = false;
    }
}