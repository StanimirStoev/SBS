// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function FillDependentSelect(masterSelectControl, dependentSelectControl, getDependentListPath) {

    var lstItems = $("#" + dependentSelectControl);
    lstItems.empty();
    lstItems.append($('<option/>',
        {
            value: null,
            text: "Select Item"
        }));

    var selectedItem = masterSelectControl.options[masterSelectControl.selectedIndex].value;

    if (selectedItem != null && selectedItem != '') {
        $.getJSON(getDependentListPath, { id: selectedItem }, function (items) {
            if (items != null && !jQuery.isEmptyObject(items)) {
                $.each(items, function (index, item) {
                    lstItems.append($('<option/>',
                        {
                            value: item.value,
                            text: item.text
                        }));
                });
            };
        });
    }

    return;
}
