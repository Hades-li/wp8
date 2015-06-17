(function () {
    "use strict";

    var nav = WinJS.Navigation;
    var session = WinJS.Application.sessionState;
    var util = WinJS.Utilities;

    //获取由中心的数据绑定部分使用的组。
    var section3Group = Data.resolveGroupReference("group4");
    var section3Items = Data.getItemsFromGroup(section3Group);

    WinJS.UI.Pages.define("/pages/hub/hub.html", {
        processed: function (element) {
            return WinJS.Resources.processAll(element);
        },

        // 每当用户导航至该页面时都要调用此函数。它
        // 使用应用程序的数据填充页面元素。
        ready: function (element, options) {
            var hub = element.querySelector(".hub").winControl;
            hub.onheaderinvoked = function (args) {
                args.detail.section.onheaderinvoked(args);
            };
            hub.onloadingstatechanged = function (args) {
                if (args.srcElement === hub.element && args.detail.loadingState === "complete") {
                    hub.onloadingstatechanged = null;
                    hub.element.focus();
                }
            }

            // TODO: 在此处初始化页面。
        },

        section3DataSource: section3Items.dataSource,

        section3ItemNavigate: util.markSupportedForProcessing(function (args) {
            var item = Data.getItemReference(section3Items.getAt(args.detail.itemIndex));
            nav.navigate("/pages/item/item.html", { item: item });
        }),

        unload: function () {
            // TODO: 响应导航到其他页。
        },

        updateLayout: function (element) {
            /// <param name="element" domElement="true" />

            // TODO: 响应布局的更改。
        },
    });
})();