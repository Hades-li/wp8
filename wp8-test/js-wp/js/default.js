// 有关“透视”模板的简介，请参阅以下文档:
// http://go.microsoft.com/fwlink/?LinkID=392284
(function () {
    "use strict";

    var activation = Windows.ApplicationModel.Activation;
    var app = WinJS.Application;
    var nav = WinJS.Navigation;
    var sched = WinJS.Utilities.Scheduler;
    var ui = WinJS.UI;

    app.addEventListener("activated", function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO:  此应用程序刚刚启动。在此处初始化
                //您的应用程序。
            } else {
                // TODO:  此应用程序已从挂起状态重新激活。
                // 在此处恢复应用程序状态。
            }

            hookUpBackButtonGlobalEventHandlers();
            nav.history = app.sessionState.history || {};
            nav.history.current.initialPlaceholder = true;

            // 优化应用程序的加载过程，并在显示初始屏幕时执行高优先级的计划作业。
            ui.disableAnimations();
            var p = ui.processAll().then(function () {
                return nav.navigate(nav.location || Application.navigator.home, nav.state);
            }).then(function () {
                return sched.requestDrain(sched.Priority.aboveNormal + 1);
            }).then(function () {
                ui.enableAnimations();
            });

            args.setPromise(p);
        }
    });

    app.oncheckpoint = function (args) {
        // TODO:  即将挂起此应用程序。在此处保存
        //需要在挂起中保留的任何状态。如果您需要
        //在应用程序挂起之前完成异步操作
        //，请调用 args.setPromise()。
        app.sessionState.history = nav.history;
    };

    function hookUpBackButtonGlobalEventHandlers() {
        // 订阅窗口对象中的全局事件
        window.addEventListener('keyup', backButtonGlobalKeyUpHandler, false)
    }

    // 常量
    var KEY_LEFT = "Left";
    var KEY_BROWSER_BACK = "BrowserBack";
    var MOUSE_BACK_BUTTON = 3;

    function backButtonGlobalKeyUpHandler(event) {
        // 释放(alt + left)或 BrowserBack 键时向后导航。
        if ((event.key === KEY_LEFT && event.altKey && !event.shiftKey && !event.ctrlKey) || (event.key === KEY_BROWSER_BACK)) {
            nav.back();
        }
    }

    app.start();
})();
