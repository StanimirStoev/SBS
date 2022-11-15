// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Fills the dropdown items that depends on master dropdown selection .
// masterSelectControl - id  master dropdown
// dependentSelectControl - id dependent dropdown
// getDependentListPath - path for the json function to get the items for the dependent dropdown
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
