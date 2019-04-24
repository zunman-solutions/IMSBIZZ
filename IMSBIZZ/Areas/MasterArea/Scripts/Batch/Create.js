$(function () {
    ko.applyBindings(new BatchCreateViewModel(), document.getElementById('CreateBatch'));   
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
    
       
    self.Create = function () {
        if (self.errors().length == 0) {
            $.blockUI({ message: '<h1>Please wait...</h1>' });
           
            var batch = {
                BatchName: self.BatchName(),
                Status: self.IsActive()             
            };    

            $.ajax({
                url: app.url.apiAction("api/Batch/CreateBatch"),
                data: JSON.stringify(batch),
                type: 'post',
                dataType: 'json',
                contentType: 'application/json',
                success: function (data) {
                    debugger;
                    swal.fire("Batch saved successully.");
                    document.location.reload(true);
                },
                error: function (data) {
                    debugger;
                    swal.fire(data);                   
                }
            }).always(function () {
                debugger;
                $.unblockUI();
            });

        } else {
            swal.fire('Please enter all required fields.');
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
 

