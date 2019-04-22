ko.bindingHandlers.summernote = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var value = ko.unwrap(valueAccessor());
        var allBindings = ko.unwrap(allBindingsAccessor())
        var optionsBinding = allBindings.summernoteOptions || {};
        var $element = $(element);
        var options = $.extend({}, optionsBinding);

        var updateObservable = function (e) {
            valueAccessor()($element.summernote('code'));
            return true;
        };

        options.callbacks = {};
        //options.callbacks.onFocus = options.callbacks.onBlur = updateObservable;

        $element.html(value).summernote(options);

        $(element).next().find('.note-editable').keyup(updateObservable);
        $(element).next().find('.note-editable').bind('DOMNodeInserted DOMNodeRemoved', updateObservable);
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var value = ko.unwrap(valueAccessor());
        if (value != $(element).summernote('code')) {
            $(element).summernote('code', value);
        }
    }
};