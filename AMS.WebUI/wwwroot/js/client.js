$(document).ready(function () {
    $("addForm").submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: "api/FacilityCostApi",
            contentType: "application/json",
            method: "post",
            data: JSON.stringify({
                title: this.elements["title"].value,
                description: this.elements["description"].value,
                kindOfUsage: this.elements["kindOfUsage"].value,
                calculationType: this.elements["calculationType"].value,
                costIncomeType: this.elements["costIncomeType"].value,
                emptyUnitShare: this.elements["emptyUnitShare"].value
            }),
            success: function(data) {
                addTableRow(data);
            }
        });
    });
});

var addTableRow = function (facilitycost) {
    $("table tbody").append("<tr><td>" +
        facilitycost.title +
        "</td>" +
        "<td>" +
        facilitycost.description +
        "</td>" +
        "<td>" +
        facilitycost.calculationType +
        "</td>" +
        "<td>" +
        facilitycost.emptyUnitShare +
        "</td>" +
        "<td>" +
        facilitycost.kindOfUsage +
        "</td>" +
        "<td>" +
        facilitycost.costIncomeType +
        "</td></tr>");
}