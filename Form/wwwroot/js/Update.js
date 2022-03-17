/*/*const { ajax } = require("jquery");*/

var silinecekPersonelEgitimId = [];
var varolanEgitimIdLer = [];
$(document).ready(function () {
    GetData();
    Okul("Okul");

});

var id;
var query = (window.location).href;
id = query.substring(query.lastIndexOf('=') + 1);
var veriler = null;

function getParameterByName(name, url = window.location.href) {
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}
 
function GetData() {
    var id = getParameterByName("id");

    $.ajax({
        type: "Get",
        url: "/Employee/GetData/" + id,
        dataType: "json",
        data: { id: id },
        async: false,
        success: function (result) {

            console.log(result);
            $("#name").val(result.employeeName);
            $("#surname").val(result.employeeSurname);
            $("#date").val(result.dateOfStartingJob);
            $('#Cinsiyet option:contains("' + result.genderId + '")').attr('selected', 'selected');
            $("#adress").val(result.employeeAdress);
            $('#Ulke option:contains("' + result.countryId + '")').attr('selected', 'selected');
            Sehirler($('#Ulke option:contains("' + result.countryId + '")').val());
            $('#Sehir option:contains("' + result.cityName + '")').attr('selected', 'selected');
            $("#a_imgFile").attr("src", result.medyaId);

       
            for (var x = 0; x < result.personelEgitimler.length; x++) {
                var y = result.personelEgitimler[x].personelEgitimId;
                $('#okulTekrarliRow').append(`<div class="row " id='eklenenOkul${y}'">
                        <div class="col-md-3">
                        <label class="control-label">Okul Tipi</label>
                        <select id="Okul${y}" class="form-select okul" selected="">
                        </select>
                        </div>
                        <div class="col-md-4">
                            <label class="control-label">Okul Adı</label>
                            <input class="form-control" name="OkulAdi" id="OkulAdi" placeholder="Seçiniz" value="${result.personelEgitimler[x].okulAdi}">
                        </div>
                        <div class="col-md-4">
                            <label class="control-label">Mezuniyet Tarihi</label>
                            <input type="date"  class="form-control" name="MezuniyetTarihi"  id="MezuniyetTarihi" value="${result.personelEgitimler[x].mezuniyetTarihi}">
                        </div>
                        <div class="col-md-1">
                            <label class="control-label"></label>
                            <button type="button" onclick="OkulEkle()" style="height:35px;width:35px">+</button>
                            <button type="button" onclick="OkulSil(${y})" style="height:35px;width:35px">-</button>
                        </div> 
                    </div>`
                )

                var nereyeBassilacak = `Okul${y}`
                Okul(nereyeBassilacak);
                $('#Okul' + y + ' option[value="' + result.personelEgitimler[x].okulId + '"]').prop('selected', true);
                varolanEgitimIdLer.push(y);
              
            }


        }
    })
};



function MedyaOlustur(id) {
    if (event.target.files.length > 0) {
        var src = URL.createObjectURL(event.target.files[0]);
        var preview = document.getElementById("a_" + id);
        preview.src = src;
        preview.style.display = "block";
    }
    console.log(id);
    var fdata = new FormData();
    var fileInput = $('#' + id)[0];
    var file = fileInput.files[0];
    fdata.append("iFormFile", file);


    $.ajax({
        type: "POST",
        url: "/Employee/MedyaOlustur/",
        data: fdata,
        contentType: false,
        processData: false,
        success: function (result) {
            console.log(result);
            if (result != 0) {
                $("#" + id).attr("mediaid", result);
                $("#medyaid").val(result);
            }
        }
    });
}
function Okul(x) {
    $.ajax({
        type: "Get",
        url: "/Employee/OkulGetir",
        dataType: "json",
        async: false,
        success: function (result) {
            console.log(result);
            var myData = result;
            var myDesign = "<option value = 0>Seçiniz.</option>";
            for (var i = 0; i < myData.length; i++) {
                myDesign += "<option value='" + myData[i].okulId + "'>" + myData[i].tanim + "</option>";
            }
            var nereyeBasilacak = "#" + x;
            $(nereyeBasilacak).html(myDesign);
        }
    })
}

function OkulSil(x) {

    var silinecek = '#eklenenOkul' + x;
    silinecekPersonelEgitimId.push(x);
    $(silinecek).remove();
   

 
  
};
function updateKayit() {
    var PersonelEgitimler = [];
    var EmployeeId = getParameterByName("id");
    var EmployeeName = $("#name").val();
    var EmployeeSurname = $("#surname").val();
    var DateOfStartingJob = $("#date").val();
    var GenderId = $("#Cinsiyet").val();
    var CountryId = $("#Ulke option:selected").val();
    var CityId = $("#Sehir option:selected").val();
    var EmployeeAdress = $("#adress").val();
    var MedyaId = $("#imgFile").attr("mediaId")

  
    var myRows = $('#okulTekrarliRow').find('[id^="eklenenOkul"]');
    var personelEgitimIlk = {};
        $.each(myRows, function (x, y) {

          
            personelEgitimIlk['OkulId'] = $(y).find('[id^="Okul"]').val();
            personelEgitimIlk['OkulAdi'] = $(y).find('[id^="OkulAdi"]').val();
            personelEgitimIlk['MezuniyetTarihi'] = $(y).find('[id^="MezuniyetTarihi"]').val();
            PersonelEgitimler.push(personelEgitimIlk);
      
    })

 

    var update = {
        EmployeeId: EmployeeId,
        EmployeeName: EmployeeName,
        EmployeeSurname: EmployeeSurname,
        DateOfStartingJob: DateOfStartingJob,
        GenderId: GenderId,
        CountryId: CountryId,
        CityId: CityId,
        EmployeeAdress: EmployeeAdress,
        MedyaId: MedyaId,
        PersonelEgitimler: PersonelEgitimler,

    }
    $.ajax({
        type: "Post",
        url: "/Employee/UpdateKayit/",
        dataType: "json",
        data: { update: update },
        async: false,
        success: function () {
          
        }
    });
    window.location.href = "/../Employee/List";
     
 }
 


function Ulkeler() {
    $.ajax({
        type: "Get",
        url: "/Employee/UlkeCekme",
        dataType: "json",
        async: false,
        success: function (result) {

            var myData = result;
            var myDesign = "";
            for (var i = 0; i < myData.length; i++) {
                myDesign += "<option value='" + myData[i].tabloId + "'>" + myData[i].tanim + "</option>";
            }
            $("#Ulke").append(myDesign);
        }
    });

}

function Sehirler() {
    $.ajax({
        type: "Get",
        url: "/Employee/CityList/" + $("#Ulke").val(),
        dataType: "json",


        async: false,
        success: function (result) {
            var myData = result;
            var myDesign = "";

            for (var i = 0; i < myData.length; i++) {
                myDesign += "<option value='" + myData[i].tabloId + "'>" + myData[i].tanim + "</option>";
                console.log(myData[i].tabloId);
            }
            $("#Sehir").html(myDesign);


        }

    });
}


function Cinsiyet() {
    $.ajax({
        type: "Get",
        url: "/Employee/CinsiyetList",
        dataType: "json",


        async: false,
        success: function (result) {
            console.log(result);
            var myData = result;
            var myDesign = " ";

            for (var i = 0; i < myData.length; i++) {
                myDesign += "<option value='" + myData[i].genderId + "'>" + myData[i].genderType + "</option>";
                console.log(myData[i].cityName);
            }
            $("#Cinsiyet").html(myDesign);

        }

    });
}



var i = $('#okulTekrarliRow').find('[id^="eklenenOkul"]')['length'];

function OkulEkle() {
    i++;

    $('#okulTekrarliRow').append(`<br><div class="row" id='eklenenOkul${i}'">
                        <div class="col-md-3">
                        <label class="control-label">Okul Tipi</label>
                        <select id="Okul${i}" class="form-select okul">
                        <option value="0">Seçiniz</option>
                        </select> 
                        </div>
                        <div class="col-md-4">
                        <label class="control-label">Okul Adı</label> 
                        <input type="text" class="form-control" name="OkulAdi" id="OkulAdi${i}">
                        </div>
                        <div class="col-md-4">
                        <label class="control-label">Mezuniyet Tarihi</label> 
                        <input type="date" class="form-control" name="MezuniyetTarihi" id="MezuniyetTarihi${i}">
                        </div>
                        <div class="col-md-1">
                        <label class="control-label"> </label>
                          <button type="button" onclick="OkulEkle(${i})" style="height:35px;width:35px">+</button>
                        <button type="button" onclick="OkulSil(${i})" style="height:35px;width:35px">-</button>

                        </div></div>`)

    var nereyeBassilacak = `Okul${i}`;
    Okul(nereyeBassilacak);

};
  
 