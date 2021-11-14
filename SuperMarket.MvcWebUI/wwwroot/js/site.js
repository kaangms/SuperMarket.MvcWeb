// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const myActionModalBodyElement = document.getElementById("ActionModalBody");
const myActionButtonElement = document.getElementById("MyActionButton");
const myModalDismissButtonElement = document.getElementById("MyModalDismissButton");



$(document).ready(function () {

    if (myActionResultTempDataMessage) {
        openActionResultModal(myActionResultTempDataMessage);
    }
});

function removeProduct(productId) {
    myActionButtonElement.style.display = "block";
    myActionButtonElement.innerHTML = "Evet";
    myActionButtonElement.href = '/Product/RemoveProduct?productId=' + productId;
    myModalDismissButtonElement.innerHTML = "Hayır";
    myActionModalBodyElement.innerHTML = "Ürünü Silmek İstediğinize Emin Misiniz?";
    $('#MyActionModal').modal('show');
}


function openActionResultModal(message) {
    myActionModalBodyElement.innerHTML = message;
    myModalDismissButtonElement.innerHTML = "Kapat";
    myActionButtonElement.style.display = "none";
    console.log(myActionButtonElement);
    $('#MyActionModal').modal('show');
}
