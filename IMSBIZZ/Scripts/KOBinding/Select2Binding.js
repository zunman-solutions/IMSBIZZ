ko.bindingHandlers.select2 = {
        update: function (element, valueAccessor, allBindingsAccessor) {
            var $elm = $(element);
            var ctorArgs = ko.unwrap(valueAccessor());
            var allBindings = allBindingsAccessor();
            var optionsBinding = allBindings.options;
            var optionsCaptionBinding = allBindings.optionsCaption;
            var ensureOptionsValue = function () {
                var optionsCaption = ko.unwrap(optionsCaptionBinding);
                
                $elm.find('option').each(function (index, optionElm) {
                    var $optionElm = $(optionElm);
                    if ($optionElm.text() && optionsCaption !== $optionElm.text()) {
                        optionElm.value = optionElm.value || optionElm.index;
                    } else {
                        $.extend(ctorArgs, { placeholder: optionsCaption });
                        $optionElm.text('').removeAttr('value');
                    }
                });
            };
            
            if (ko.isObservable(optionsBinding)) {
                optionsBinding.subscribe(ensureOptionsValue);
            }
            if (ko.isObservable(optionsCaptionBinding)) {
                optionsCaptionBinding.subscribe(ensureOptionsValue);
            }

            ensureOptionsValue();

            $elm.select2(ctorArgs);
            
            $elm.on('change.select2', function (e) {
                if ($elm.find('option').length === 0 && !ko.unwrap(optionsCaptionBinding)) {
                    $elm.select2('val', null);
                }
            });
            
            $elm.on('select2-selecting', function (e) {
                var multiple = $elm.data('select2').opts.multiple || $elm.prop('multiple');
                var data = e.choice || e.object;
                if (multiple) {
                    var selectedIndices = $elm.data('select2-selected-indices') || [];
                    selectedIndices.push(data.element[0].index);
                    $elm.find('option').each(function (index, optionElm) {
                        optionElm.selected = $.inArray(optionElm.index, selectedIndices) > -1;
                    });
                    $elm.data('select2-selected-indices', selectedIndices);
                } else {
                    $elm.val(data.id);
                    $elm.trigger('change');
                }
            });
            
            $elm.on('select2-loaded', function(e) {
                console.log(e);
            });

            $elm.on('select2-removing', function (e) {
                var selectedIndices = $.grep($elm.data('select2-selected-indices') || [], function (value) {
                    var data = e.object || e.choice;
                    return value != data.element[0].index;
                });
                $elm.data('select2-selected-indices', selectedIndices)
            });
            
            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                $elm.select2('destroy');
            });
        }
};

//jsfiddle.net/ossipoff/nwzmv61q/