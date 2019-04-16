$(function () {
    var batch = $.parseJSON(CorrectJsonObject(dbBatch));
    ko.applyBindings(EditBatchViewModel(batch));
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

var EditBatchViewModel = function (batch) {
    //Make the self as 'this' reference
    var self = this;
    self.BatchId = ko.observable(batch.BatchId);
    self.BatchName = ko.observable(batch.BatchName).extend({ required: true });
    self.IsActive = ko.observable(batch.IsActive).extend({ required: true });
    
   
    self.Edit = function () {
        if (self.errors().length == 0) {
            $.blockUI({ message: '<h1>Please wait...</h1>' });
           
                        
                            var batch = {
                                BatchId: self.BatchId(),
                                BatchName: self.BatchName(),                                
                                IsActive: self.IsActive()                              
            };

            $.post(app.url.api("EditBatch", "api/Batch", { controller: "BatchAPI" }), { batchViewModel: batch })
                                .done(function (data, status) {
                                    swal({
                                        title: "",
                                        text: "Batch updated successfully.",
                                        type: "info",
                                        showCancelButton: false,
                                        showLoaderOnConfirm: true,
                                        closeOnConfirm: false,
                                        confirmButtonText: "ok",
                                        confirmButtonColor: "#337ab7"
                                    }, function () {
                                            window.location.href = app.url.action("Index", { controller: "Batch", area:"MasterArea"});
                                    });
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
       

    // init validations
    self.errors = ko.validation.group(self);
}
  