// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetNomenclatures() {
    let xhr = new XMLHttpRequest();
    xhr.open('GET', '/api/nomenclatures', false);
    xhr.responseType = 'json';
    xhr.send();
    return xhr.response;
}

function fillTable() {

    let idnomenclatureTBody = "nomenclatureTBody";
    let xhr = new XMLHttpRequest();
    xhr.open('GET', '/api/nomenclatures');
    xhr.responseType = 'json';
    xhr.onload = function () {
        let status = xhr.status;
        if (status == 200) {
            let data = xhr.response;
            let tb = document.getElementById(idnomenclatureTBody);
            tb.innerHTML = null;
            for (let i = 0; i < data.length; i++) {
                let tr = document.createElement('tr');
                let id = "id" + data[i].id;
                tr.id = id;
                //tr.onclick = () => rowClick(id);
                tb.appendChild(tr);
                let tdName = document.createElement("td");
                tr.appendChild(tdName);
                tdName.innerHTML = data[i].name;
                let tdPrice = document.createElement("td");
                tdPrice.innerHTML = data[i].price;
                tr.appendChild(tdPrice);



            }
        }

    }
    xhr.send();

}

function editItem(id, name, price) {
    let a = 1;


}

function rowClick(id) {
    let sr = document.getElementsByClassName('selectedRow');
    // ...

}

function postNomenclature(formId) {
    let formData = new FormData();
    let response = await fetch('/api/nomenclatures', { method: 'POST', body: formData });

    let idnomenclatureTBody = "nomenclatureTBody";
    let xhr = new XMLHttpRequest();
    xhr.open('GET', '/api/nomenclatures');
    xhr.responseType = 'json';
    xhr.onload = function () {
        let status = xhr.status;
        if (status == 200) {
            let data = xhr.response;
            let tb = document.getElementById(idnomenclatureTBody);
            tb.innerHTML = null;
            for (let i = 0; i < data.length; i++) {
                let tr = document.createElement('tr');
                let id = "id" + data[i].id;
                tr.id = id;
                //tr.onclick = () => rowClick(id);
                tb.appendChild(tr);
                let tdName = document.createElement("td");
                tr.appendChild(tdName);
                tdName.innerHTML = data[i].name;
                let tdPrice = document.createElement("td");
                tdPrice.innerHTML = data[i].price;
                tr.appendChild(tdPrice);



            }
        }

    }
    xhr.send();
}