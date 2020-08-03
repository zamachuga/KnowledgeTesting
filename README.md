# KnowledgeTesting
Подключено: NUnit, Moq, EF6, PostgreSql, Ninject

# Установка для разработчика
1. Клонировать репозиторий.
2. Серверная часть - стандартный C# AspNet.
3. Клиентская чать (VueJs):

Потребуется Visual Studio Code и NodeJs(для компиляции webpack и отслеживания зависимостей).

Открыть папку "Scripts/ClientApp".

В терминале (внутри VSCode) выполнить команду "npm install"

Выполнить конфигурацию клиента в файле "Scripts\ClientApp\src\configs\settings.js". 
UrlApi - адрес серверной части. 
В режиме отладки в Visual Studio может запускаться IISExpress у него свой порт на Localhost - надо соответствующе настроить адрес в клиенте. IsDebug - бесполезная настройка.

PS: в проекте Visual Studio лучше настроить, чтобы не открывалась страница по умолчанию, т.к. к ней привязана **скомпилированная версия** клиента.

# Разработка
Запускаем серверную часть Visual Studio.
Запускаем клиентскую часть VSCode в терминале командой "npm run dev" - откроется браузер, в крайнем случае в терминале адрес для просмотра.
Выполняем изменения кода необходимые.

# Компиляция клиента
Компилируем в VSCode терминале командой "npm run build". На выходе получим файл "Scripts\ClientApp\dist\build.js" (+ дополнительные). Всё.
Стартовая страница в проекте Visual Studio уже настравлена на файл скомпилированной версии клиента (поэтому было бесполезно запускать просмотр до компиляции клиента).

# ERD:

![ERD](https://github.com/zamachuga/KnowledgeTesting/blob/master/ERD.JPG)
