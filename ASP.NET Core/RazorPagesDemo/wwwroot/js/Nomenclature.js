// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function fillNomenclatureTable(idTable) {

    let idnomenclatureTBody = idTable;
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
                fillOneRow(data[i].id, data[i].name,data[i].price)
            }
        }

    }
    xhr.send();

}

function fillOneRow(id, name, price) {
    let idrow = "id" + id;
    let tr = document.getElementById(idrow);
    tr.innerHTML = null;
    let tdName = document.createElement("td");
    tr.appendChild(tdName);
    tdName.innerHTML = name;
    let tdPrice = document.createElement("td");
    tdPrice.innerHTML = price;
    tr.appendChild(tdPrice);
    let buttons = document.createElement("td");
    let button = document.createElement("button");
    button.onclick = () => editClick(id, name, price);
    button.innerText = 'Edit';
    buttons.appendChild(button);
    tr.appendChild(buttons);
}

function editClick(id,name,price){
    let myModal = new bootstrap.Modal(document.getElementById('editModal'), {});
    document.getElementById('NomenclatureEdit.Id').value = id;
    document.getElementById('NomenclatureEdit.Name').value = name;
    document.getElementById('NomenclatureEdit.Price').value = price;
    myModal.show();
}

function editsavechanges() {
    let id = document.getElementById('NomenclatureEdit.Id').value;
    let name = document.getElementById('NomenclatureEdit.Name').value;
    let price = document.getElementById('NomenclatureEdit.Price').value;

    fillOneRow(id, name, price);

    let modal = bootstrap.Modal.getInstance(document.getElementById('editModal'));
    modal.hide();
    var data = new FormData(/*document.getElementById("modalFormEdit")*/);

    data.append("Id", id);
    data.append("Name", name);
    data.append("Price", price);

    let jsonData = JSON.stringify({ id:id, name:name, price:price });

    fetch('/api/nomenclatures/'+id, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: jsonData
    }).then(res => {
        let result = res.json();
        console.log('Success:', result);
    }).then(res => {
        console.error('Error:', res.statusText);
    }).catch(res => {
        console.error('Error:', res);
    });

    //let result = await fetch("api/nomenclatures",)

//    let form = document.getElementById('modalFormEdit');
//    form.submit();
}

function submitModalEdit() {
    let id = document.getElementById('NomenclatureEdit.Id').value;
    let name = document.getElementById('NomenclatureEdit.Name').value;
    let price = document.getElementById('NomenclatureEdit.Price').value;
    fillOneRow(id, name, price);
    let modal = bootstrap.Modal.getInstance(document.getElementById('editModal'));
    modal.hide();


}

   //document.getElementById('modalFormEdit').addEventListener('submit', function (event) {
   //     event.preventDefault(); // Prevent the default form submission

   //     let form = event.target;
   //     let formData = new FormData(form);

   //     fetch('/api/nomenclatures', {
   //         method: 'POST',
   //         body: formData
   //     }).then(res => {
   //         let result = res.json();
   //         console.log('Success:', result);
   //     }).then(res => {
   //         console.error('Error:', res.statusText);
   //     }).catch(res => {
   //         console.error('Error:', error);
   //     });
   // });