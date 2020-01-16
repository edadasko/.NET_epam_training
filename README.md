# .NET_epam_training
### Day 1
- Реализовать методы быстрой сортировки и сортировки слиянием для целочисленного массива.
- Протестировать работу методов в консольном приложении или с помощью модульного тестирования.

### Day 2
- Даны два целых знаковых четырех байтовых числа и две позиции битов i и j (i < j). Реализовать алгоритм InsertNumber вставки битов с j-ого по i-ый бит одного числа в другое так, чтобы биты второго числа занимали позиции с бита j по бит i (биты нумеруются справа налево). Разработать модульные тесты (NUnit и MS Unit Test) для тестирования метода.
- Реализовать метод FindNextBiggerNumber, который принимает положительное целое число и возвращает ближайше наибольшее целое, состоящее из цифр исходного числа, и - 1 (null), если такого числа не существует. Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода.
- Добавить к методу FindNextBiggerNumber возможность вернуть время нахождения заданного числа, рассмотрев различные языковые возможности. Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода.
- Реализовать метод FilterDigit который принимает список целых чисел и фильтрует список, таким образом, чтобы на выходе остались только числа, содержащие заданную цифру. LINQ не использовать.
- Реализовать алгоритм FindNthRoot, позволяющий вычислять корень n-ой степени ( n∈N ) из числа ( a∈R ) методом Ньютона с заданной точностью. Разработать модульные тесты (NUnit и (или) MS Unit Test) для тестирования метода.

### Days 3-4
- Разработать класс, позволяющий выполнять вычисления НОД по алгоритму Евклида для двух, трех и т.д. целых чисел. Методы класса помимо вычисления НОД должны определять значение времени, необходимое для выполнения расчета. Добавить к разработанному классу методы, реализующие алгоритм Стейна (бинарный алгоритм Евклида) для расчета НОД двух, трех и т.д. целых чисел). Методы должны также определять значение времени, необходимое для выполнения расчетов. Разработать unit-тесты для тестирования методов данного типа.
- Реализовать метод расширения для получения строкового двоичного представления вещественного числа двойной точности в формате IEEE 754 (желательно не использовать готовые классы-конверторы). Разработать модульные тесты.

### Days 5-6
- Разработать неизменяемый класс Polynomial (полином) для работы с многочленами степени от одной переменной вещественного типа (в качестве внутренней структуры для хранения коэффициентов использовать sz-массив). Для разработанного класса
    - переопределить виртуальные методы класса Object;
    - перегрузить операции, допустимые для работы с многочленами (исключая деление многочлена на многочлен), включая “==” и “!=”. Разработать unit-тесты.
- Реализовать алгоритм “пузырьковой” сортировки непрямоугольного (jagged array) целочисленного массива (методы сортировки класса System.Array не использовать) таким образом, чтобы была возможность упорядочить строки матрицы:
    - в порядке возрастания (убывания) сумм элементов строк матрицы;
    - в порядке возрастания (убывания) максимальных элементов строк матрицы;
    - в порядке возрастания (убывания) минимальных элементов строк матрицы;
Разработать unit-тесты.

### Days 7-8
- Разработать класс Book (ISBN, автор, название, издательство, год издания, количество страниц, цена), переопределив для него необходимые методы класса Object. Для объектов класса реализовать отношения эквивалентности и порядка (используя соответствующие интерфейсы). Для выполнения основных операций со списком книг, который можно загрузить и, если возникнет необходимость, сохранить в некоторое хранилище BookListStorage разработать класс BookListService (как сервис для работы с коллекцией книг) с функциональностью AddBook (добавить книгу, если такой книги нет, в противном случае выбросить исключение); RemoveBook (удалить книгу, если она есть, в противном случае выбросить исключение); FindBookByTag (найти книгу по заданному критерию); SortBooksByTag (отсортировать список книг по заданному критерию), при реализации делегаты не использовать! Работу классов продемонстрировать на примере консольного приложения. В качестве хранилища использовать двоичный файл, для работы с которым использовать только классы BinaryReader, BinaryWriter. Хранилище в дальнейшем может измениться/добавиться.
- Разработать систему типов для описания работы с банковским счетом. Состояние счета определяется его номером, данными о владельце счета (имя, фамилия), суммой на счете и некоторыми бонусными баллами, которые увеличиваются/уменьшаются каждый раз при пополнении счета/списании со счета на величины различные для пополнения и списания и рассчитываемые в зависимости от некоторых значений величин «стоимости» баланса и «стоимости» пополнения. Величины «стоимости» баланса и «стоимости» пополнения являются целочисленными значениями и зависят от градации счета, который может быть, например,  Base, Gold, Platinum. Для работы со счетом реализовать следующие возможности: 
    - выполнить пополнение на счет;
    - выполнить списание со счета; 
    - создать новый счет; 
    - закрыть счет. 

    Информация о счетах храниться в бинарном файле. Работу классов продемонстрировать на примере консольного приложения.  При проектировании типов учитывать следующие возможности расширения/изменения функциональности
    - добавление новых видов счетов;
    - изменение/добавление источников хранения информации о счетах;
    - изменение логики расчета бонусных баллов.

### Days 9-11
- Для объектов класса Book (ISBN, автор, название, издательство, год издания, количество страниц, цена) (домашнее задание 8-ого дня) реализовать возможность строкового представления различного вида.
- Не изменяя класс Book, добавить для объектов данного класса дополнительную возможность форматирования, изначально не предусмотренную классом.
- Для реализованных в пп. 1, 2 функциональностей разработать модульные тесты.
- Выполнить рефакторинг класса (с целью сокращения повторного кода) в алгоритмах Евклида (для рефакторинга использовать делегаты, рефакторинг возможен только в случае, когда все метод находятся в одном классе!). Интерфейс класса измениться не должен.
- В класс с алгоритмом сортировки не прямоугольной матрицы, принимающим как компаратор интерфейс IComparer<int[]> добавить метод, принимающий как параметр делегат-компаратор, инкапсулирующий логику сравнения строк матрицы. Протестировать работу разработанного метода на примере сортировки матрицы, используя прежние критерии сравнения. Класс реализовать двумя способами, «замкнув» в первом варианте реализацию метода сортировки с делегатом на метод с интерфейсом, во втором – наоборот.

### Day 12
- Для приложения с сервисом книг реализовать возможность логирования сообщений различного уровня, предусмотрев возможность использования различных фреймворков для логирования.
- Разработать класс для имитации часов с обратным отсчетом, реализующий возможность по истечении назначенного времени (время ожидания предоставляется классу пользователем) передавать сообщение и дополнительную информацию о событии любому подписавшемуся на событие типу. Предусмотреть возможность подписки на событие в нескольких классах. Продемонстрировать работу класса в консольном приложении.

### Days 13-14
- Разработать обобщенный класс-коллекцию Queue, реализующий основные операции для работы с очередью, и предоставляющий возможность итерирования, реализовав итератор «вручную» (без использования блок-итератора yield). Протестировать методы разработанного класса.
- Создать обобщенные классы для представления квадратной, симметрической и диагональной матриц (симметрическая матрица – это квадратная матрица, которая совпадает с транспонированной к ней; диагональная матрица – это квадратная матрица, у которой элементы вне главной диагонали заведомо имеют значения по умолчанию типа элемента). Описать в созданных классах событие, которое происходит при изменении элемента матрицы с индексами (i, j). Расширить функциональность существующей иерархии классов, добавив возможность операции сложения двух матриц любого типа. Разработать unit-тесты.
- Разработать обобщенный класс-коллекцию BinarySearchTree (бинарное дерево поиска). Предусмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): для реализации использовать блок-итератор (yield). Протестировать
разработанный класс, используя следующие типы:
    - System.Int32 (использовать сравнение по умолчанию и подключаемый компаратор);
    - System.String (использовать сравнение по умолчанию и подключаемый компаратор);
    - пользовательский класс Book, для объектов которого реализовано отношения порядка (использовать сравнение по умолчанию и подключаемый компаратор);
    - пользовательскую структуру Point, для объектов которого не реализовано отношения порядка (использовать подключаемый компаратор).

### Days 15-16
Разработать систему типов для описания работы с банковским счетом. Состояние счета определяется его номером, данными о владельце счета (имя, фамилия), суммой на счете и некоторыми бонусными баллами, которые увеличиваются/уменьшаются каждый раз при пополнении счета/списании со счета на величины различные для пополнения и списания и рассчитываемые в зависимости от некоторых значений величин «стоимости» баланса и «стоимости» пополнения.
Величины «стоимости» баланса и «стоимости» пополнения являются целочисленными значениями и зависят от типа счета, который может быть, например, Base, Gold, Platinum.
Для работы со счетом реализовать следующие возможности:
- выполнить пополнение на счет;
- выполнить списание со счета;
- создать новый счет;
- закрыть счет.

Для хранения информации о счетах можно использовать fake-имплементацию репозитория (хранилища) в виде класса-обертки для коллекции List<Account>. Работу классов продемонстрировать на примере консольного приложения. При проектировании типов учитывать следующие возможности расширения/изменения функциональности
- добавление новых видов счетов;
- изменение/добавление источников хранения информации о счетах;
- изменение логики расчета бонусных баллов;
- изменении логики генерации номера счета.

Для организации классов и интерфейсов использовать “The Stairway pattern”.
Для разрешения зависимостей использовать Ninject-фреймворк.
Протестировать слой Bll (NUnit и Moq фреймворки). 

### Days 17-18
В текстовом файле построчно хранится информация о URL-адресах, представленных в виде scheme://host/URL‐path?parameters, где сегмент parameters - это набор пар вида key=value, при этом сегменты URL‐path и parameters или сегмент parameters могут отсутствовать.
Разработать систему типов (руководствоваться принципами SOLID) для экспорта данных, полученных на основе разбора информации текстового файла в XML-документ.

### Days 19-20
Добавить в проект для работы с банковским счетом реализацию DAL, реализуя его как обертку над ORM ADO.NET Entity Framework. Протестировать работу в консоли. Если возникнет необходимость, выполнить ”сквозные” изменения в solution-e. (BLL, BLL.Interface и т.п.).


