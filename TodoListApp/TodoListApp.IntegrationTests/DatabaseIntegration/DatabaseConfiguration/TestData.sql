Insert Into Users (UserId, Email, PasswordHash, Points) Values (1, 'testEmail', 'passHash', 0);
Insert Into Users (UserId, Email, PasswordHash, Points) Values (2, 'test@email.com', 'hash123', 23);
Insert Into Users (UserId, Email, PasswordHash, Points) Values (3, 'testowy@email.com', 'secretHash', 99);

Insert Into Boards (TasksBoardId, CategoryName, UserId) Values (1, 'ogólne', 1);
Insert Into Boards (TasksBoardId, CategoryName, UserId) Values (2, 'programowanie', 1);
Insert Into Boards (TasksBoardId, CategoryName, UserId) Values (3, 'szkolne', 3);
Insert Into Boards (TasksBoardId, CategoryName, UserId) Values (4, 'domowe', 3);
Insert Into Boards (TasksBoardId, CategoryName, UserId) Values (5, 'hobbystyczne', 3);

Insert Into Tasks (SingleTaskId, TaskName, CreatedAt, PredictedFinishDate, Priority, BoardTasksBoardId) Values (1, 'wyjazd na zakupy', '2021-01-27:09:43:00', '2021-01-28:12:00:00', 1, 1);
Insert Into Tasks (SingleTaskId, TaskName, CreatedAt, PredictedFinishDate, Priority, BoardTasksBoardId) Values (2, 'wyjście z psem', '2021-01-27:09:44:10', '2021-01-28:19:30:00', 1, 1);
Insert Into Tasks (SingleTaskId, TaskName, CreatedAt, PredictedFinishDate, Priority, BoardTasksBoardId) Values (3, 'przeczytanie książki "ASP.NET Core"', '2021-01-28:12:12:14', '2021-02-27:22:00:00', 0, 2);
Insert Into Tasks (SingleTaskId, TaskName, CreatedAt, PredictedFinishDate, Priority, BoardTasksBoardId) Values (4, 'napisanie aplikacji TODOList', '2021-01-28:12:15:00', '2021-03-16:15:30:00', 2, 2);
Insert Into Tasks (SingleTaskId, TaskName, CreatedAt, PredictedFinishDate, Priority, BoardTasksBoardId) Values (5, 'Realizacja kursu GIT', '2021-01-28:19:51:11', '2021-02-17:19:51:11', 1, 2);
Insert Into Tasks (SingleTaskId, TaskName, CreatedAt, PredictedFinishDate, Priority, BoardTasksBoardId) Values (6, 'napisanie referatu', '2021-02-01:18:00:00', '2021-02-09:20:00:00', 2, 3);
Insert Into Tasks (SingleTaskId, TaskName, CreatedAt, PredictedFinishDate, Priority, BoardTasksBoardId) Values (7, 'posprzątać w pokoju', '2021-02-01:18:01:00', '2021-02-02:18:01:00', 0, 4);
Insert Into Tasks (SingleTaskId, TaskName, CreatedAt, PredictedFinishDate, Priority, BoardTasksBoardId) Values (8, 'umyć okna', '2021-02-01:18:02:50', '2021-02-03:08:00:00', 0, 4);


Insert Into TaskDetails (TaskDetailsId, TaskDetailName, Description, Done, SingleTaskId) Values (1, 'rozdział III o autoryzacji', 'Kluczowy rodział należy go powtórzyć po przeczytaniu całej książki', 0, 3);
Insert Into TaskDetails (TaskDetailsId, TaskDetailName, Description, Done, SingleTaskId) Values (2, 'sporządzenie notatek', '', 0, 3);
Insert Into TaskDetails (TaskDetailsId, TaskDetailName, Description, Done, SingleTaskId) Values (3, 'Uwaga!', 'Przed sprzątaniem należy wynieść sprzęt elektroniczny z pomieszczenia', 1, 7);

