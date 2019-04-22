$(function () {
    var urlDetails = $.parseJSON(CorrectJsonObject(selectedUrlDetail));
    ko.applyBindings(EditViewModel(urlDetails));
});

ko.validation.rules.pattern.message = 'Invalid.';

ko.validation.init({
    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    messageTemplate: null,
    decorateInputElement: true,
    errorsAsTitle: false
}, true);

var Item = function (Url, StatusCode) {
    var self = this;
    self.AlternateUrl = ko.observable(Url);
    self.StatusCode = ko.observable(StatusCode);
};

var EditViewModel = function (url) {
    //Make the self as 'this' reference
    var self = this;
    self.AlternateUrls = ko.observableArray();
    ko.utils.arrayFilter(url.AlternateUrlDetails, function (item) {
        self.AlternateUrls.push(new Item(item.AlternateUrl,item.StatusCode))
    });
    
    self.Types = ["Default", "400", "402", "500"],
    self.Id = ko.observable(url.Id);
    self.Token = ko.observable(url.Token);
    self.SelectedStatusCode = ko.observable();
    self.EnteredUrl = ko.observable();
    self.LongUrl = ko.observable(url.LongUrl).extend({ required: true });
    self.ShortUrl = ko.observable(url.ShortUrl).extend({ required: true });
    self.ExpiredOn = ko.observable(url.ExpiredOn).extend({ required: true });
    self.IsActive = ko.observable(url.IsActive);
    self.Description = ko.observable(url.Description);
    self.isInvalid = ko.observable(false);

    self.addNewItem = function () {
        var flag = false;
        ko.utils.arrayFilter(self.AlternateUrls(), function (item) {
            if (item.StatusCode() == self.SelectedStatusCode() || item.AlternateUrl() == self.EnteredUrl()) {
                self.isInvalid(true);
                swal(".Already Set an alternate Url for the selected status code")
                flag = true;
            }
        });
        if (!flag)
            self.AlternateUrls.push(new Item(self.EnteredUrl(), self.SelectedStatusCode()));
    };
    self.removeRow = function (data) {
        self.AlternateUrls.remove(data);
    };
    self.Edit = function () {
        if (self.errors().length == 0) {
            $.blockUI({ message: '<h1>...Please wait</h1>' });
           
                        
                            var urlDetail = {
                                Id: self.Id(),
                                Token: self.Token(),
                                LongUrl: self.LongUrl(),
                                ShortUrl: self.ShortUrl(),
                                ExpiredOn: self.ExpiredOn(),
                                IsActive: self.IsActive(),
                                Description: self.Description(),
                                AlternateUrlDetails: self.AlternateUrls()
            };

                            $.post(app.url.action("Edit", { controller: "Home" }), { urlDetails: urlDetail })
                                .done(function (data, status) {
                                    swal({
                                        title: "",
                                        text: ".Url detail update successfully",
                                        type: "info",
                                        showCancelButton: false,
                                        showLoaderOnConfirm: true,
                                        closeOnConfirm: false,
                                        confirmButtonText: "ok",
                                        confirmButtonColor: "#337ab7"
                                    }, function () {
                                        window.location.href = app.url.action("Index", { controller: "Home" });
                                    });
                                })
                                .fail(function (data, status) {
                                    swal(data);
                                })
                                .always(function () {
                                    $.unblockUI();
                                });
                      
        } else {
            swal('.Please enter all required fields');
            self.errors.showAllMessages();
        }
    };   
    self.statusCodeChange = function (data) {
        var match = ko.utils.arrayFilter(self.AlternateUrls(), function (item) {

            if (item.SelectedStatusCode() == data.SelectedStatusCode()) {
                if (self.AlternateUrls().length > 1) {
                    self.isInvalid(true);
                    swal(".Already Set an alternate Url for the selected status code")
                }
            }
            return false;
        });
    }
    self.Reset = function () {
        Object.keys(self).forEach(function (name) {
            if (ko.isWritableObservable(self[name])) {
                self[name](undefined);
            }
        });
    };

    // init validations
    self.errors = ko.validation.group(self);
}
  