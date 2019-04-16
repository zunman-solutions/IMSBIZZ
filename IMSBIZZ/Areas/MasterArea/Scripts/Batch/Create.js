$(function () {
    ko.applyBindings(new BatchCreateViewModel());   
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



var BatchCreateViewModel = function () {
    //Make the self as 'this' reference
    var self = this;
   
    self.BatchName = ko.observable().extend({ required: true });
    self.IsActive = ko.observable(true).extend({ required: true });
    self.SelectedStatusCode = ko.observable();   
    
       
    self.Create = function () {
        if (self.errors().length == 0) {
            $.blockUI({ message: '<h1>Please wait...</h1>' });
           
            var batch = {
                BatchName: self.BatchName(),
                IsActive: self.IsActive()             
            };           

            $.post(app.url.api("CreateBatch", "api/Batch", { controller: "BatchAPI" }), { batchViewModel: batch })
                                .done(function (data, status) {
                                    swal("Batch saved successully.");
                                    document.location.reload(true);
                                })
                                .fail(function (data, status) {
                                    swal(data);
                                })
                                .always(function () {
                                    $.unblockUI();
                                });
                       
           
        } else {
            swal('Please enter all required fields.');
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
};
 

