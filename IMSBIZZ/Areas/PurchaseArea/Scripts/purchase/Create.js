
$(function () {
    ko.applyBindings(new UrlReWriterViewModel());   
});

ko.validation.init({
    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    messageTemplate: null,
    decorateInputElement: true,
    errorsAsTitle: false
}, true);

ko.validation.rules.pattern.message = 'Invalid.';

var Item = function (Url, StatusCode) {
    var self = this;
    self.Url = ko.observable(Url);
    self.StatusCode = ko.observable(StatusCode);
};


var UrlReWriterViewModel = function () {
    //Make the self as 'this' reference
    var self = this;
   
    self.AlternateUrls = ko.observableArray();
    self.Types =  ["Default", "400", "402", "500"],
    self.Token = ko.observable();
    self.SelectedStatusCode = ko.observable();
    self.EnteredUrl = ko.observable();
    self.LongUrl = ko.observable().extend({ required: true });
    self.ShortUrl = ko.observable().extend({ required: true });
    self.ExpiredOn = ko.observable().extend({ required: true });
    self.IsActive = ko.observable(true);
    self.Description = ko.observable();
    self.isInvalid = ko.observable();
    
    self.GenerateUrl = function () {
        if (self.LongUrlError().length == 0) {
            var _longUrl = self.LongUrl();
            $.post(app.url.action("GetShortUrl", { controller: "Home" }))
                .done(function (data, status) {
                    var origin = window.location.origin + "/" + data;
                    self.ShortUrl(origin);
                    self.Token(data);
                })
                .fail(function (data, status) {
                    swal(data);
                })
                .always(function () {
                    $.unblockUI();
                });
        }
        else {
            self.LongUrlError.showAllMessages();
        }

    };
    
    self.addNewItem = function () {
        var flag = false;
         ko.utils.arrayFilter(self.AlternateUrls(), function (item) {
             if (item.StatusCode() == self.SelectedStatusCode() || item.Url()==self.EnteredUrl()) {
                    self.isInvalid(true);
                swal(".Already Set an alternate Url for the selected status code")
                flag= true;
            }
        });
        if (!flag)
        self.AlternateUrls.push(new Item(self.EnteredUrl(),  self.SelectedStatusCode()));
    };

    self.removeRow = function (data) {
        self.AlternateUrls.remove(data);
    };
    self.Create = function () {
        if (self.errors().length == 0) {
            $.blockUI({ message: '<h1>...Please wait</h1>' });
           
            var urlDetail = {
                Token:self.Token(),
                LongUrl: self.LongUrl(),
                ShortUrl: self.ShortUrl(),
                ExpiredOn: self.ExpiredOn(),
                IsActive:self.IsActive(),
                Description: self.Description(),
                AlternateUrlDetails: self.AlternateUrls()
            };           

            $.post(app.url.action("Create", { controller: "Home" }), { urlDetails: urlDetail })
                                .done(function (data, status) {
                                    swal(".Url created successully");
                                    document.location.reload(true);
                                })
                                .fail(function (data, status) {
                                    alert(data);
                                })
                                .always(function () {
                                    $.unblockUI();
                                });
                       
           
        } else {
            swal('.Please enter all required fields');
            self.errors.showAllMessages();
        }
    };
    self.Reset = function () {
        Object.keys(self).forEach(function (name) {
            if (ko.isWritableObservable(self[name])) {
                self[name](undefined);
            }
        });
        if (ko.validation.utils.isValidatable(this.location)) {
            self.location.rules.removeAll();
        }
    };
    

    // init validations
    self.errors = ko.validation.group(self);
    self.LongUrlError = ko.validation.group([self.LongUrl]);
};
 

