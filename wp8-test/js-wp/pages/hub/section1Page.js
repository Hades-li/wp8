(function () {
    "use strict";

    var ControlConstructor = WinJS.UI.Pages.define("/pages/hub/section1Page.html", {
        // 在加载页面控制内容、
        // 激活控件且
        // 结果元素成为 DOM 的父级后，调用此函数。
        ready: function (element, options) {
            options = options || {};
        },
    });

    // 下列行将此控件构造函数作为全局函数公开。
    // 这使您可将此控件用作
    // data-win-control 属性中的声明性控件。

    WinJS.Namespace.define("HubApps_SectionControls", {
        Section1Control: ControlConstructor
    });
})();