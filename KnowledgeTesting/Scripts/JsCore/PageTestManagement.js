// Подготовка страницы.
function InstancePageTestManagement(CurrentContext) {
  PreparePageStructureToTest();
  GetAllQuestions(CurrentContext);
  ShowAllTests(CurrentContext);
}

// Получить список всех квестов.
function GetAllQuestions(CurrentContext) {
  $.ajax({
    url: '/TestManagement/GetAllTests',
    type: 'GET',
    dataType: 'json',
    success: function (data) {
      CurrentContext.DataModels.AllTests = data;
      //console.log("GetAllQuestions"); console.log(CurrentContext.DataModels.AllTests);
    }
  });
}

function ShowAllTests(CurrentContext) {
  var _strResult = "";

  _strResult += '<table id="TableTests" border="1px">'
  _strResult += '<tr><td>№ теста</td><td>Название</td><td colspan=2>Описание</td></tr>'

  //console.log("ShowAllTests"); console.log(CurrentContext.DataModels.AllTests);
  $.each(CurrentContext.DataModels.AllTests, function (index, Test) {
    console.log(Test);

    _strResult += "<tr>";
    _strResult += "<td>" + Test.Id + "</td>";
    _strResult += "<td>" + Test.Name + "</td>";
    _strResult += "<td>" + Test.Description + "</td>";
    _strResult += "<td>" + "<button id=\"" + Test.Id + "\">Редактировать</button>" + "</td>";
    _strResult += "</tr>";
  });
  _strResult += '</table>'

  $("#Tests").html(_strResult);
}

// Подготовить структуру блока контента.
function PreparePageStructureToTest() {
  $('#Content').html(
    "<div id=\"Tests\"></div>"
  );
}