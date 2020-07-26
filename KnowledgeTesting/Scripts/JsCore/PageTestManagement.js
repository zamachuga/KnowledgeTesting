// Подготовка страницы.
function InstancePageTestManagement(CurrentContext) {
  PreparePageStructureToTest();
  GetAllQuestions(CurrentContext);
}

// Получить список всех квестов.
function GetAllQuestions(CurrentContext) {
  $.ajax({
    url: '/TestManagement/GetAllTests',
    type: 'POST',
    dataType: 'json',
    success: function (data) {
      CurrentContext.DataModels.AllTests = data;
      ShowAllTests(CurrentContext);
    }
  });
}

// Отобразить список всех тестов.
function ShowAllTests(CurrentContext) {
  var _strResult = "";

  _strResult += '<div><button id="btn_CreateTest" onclick="GoCreateTest(this)">Создать тест</button></div>';
  _strResult += '<table id="TableTests" border="1px">'
  _strResult += '<tr><td>№ теста</td><td>Название</td><td>Описание</td><td>Управление</td></tr>'

  //console.log("ShowAllTests"); console.log(CurrentContext.DataModels.AllTests);
  $.each(CurrentContext.DataModels.AllTests, function (index, Test) {
    _strResult += "<tr>";
    _strResult += "<td>" + Test.Id + "</td>";
    _strResult += "<td>" + Test.Name + "</td>";
    _strResult += "<td>" + Test.Description + "</td>";
    _strResult += '<td><button id="' + Test.Id + '" onclick="GoEditTest(this)">Редактировать</button></td>';
    _strResult += "</tr>";
  });
  _strResult += '</table>'

  $("#Tests").html(_strResult);
}

// Перейти к редактированию теста.
function GoEditTest(BtnOnClick) {
  alert('Редактировать тест: ' + BtnOnClick.id);
  _StructureEditTest =''
    + '<div></div>'
    ;
}

// Перейти к редактированию теста.
function GoCreateTest(BtnOnClick) {
  alert('Редактировать тест: ' + BtnOnClick.id);
  _StructureEditTest = ''
    + '<div></div>'
    ;
}

// Подготовить структуру блока контента.
function PreparePageStructureToTest() {
  $('#Content').html(
    "<div id=\"TestEdit\"></div>"
    + "<div id=\"Tests\"></div>"
  );
}