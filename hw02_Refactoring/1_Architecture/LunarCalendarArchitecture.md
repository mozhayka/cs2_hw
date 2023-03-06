# Архитектура
### Основные классы

#### Вычисления
```c#
public interface IAspectCalculator {
  // вычисляет аспекты
}
public class AspectCalculator {
  // вычисляет аспекты перебором всех временных моментов
}
public interface ILBKCalculator {
  // вычисляет время ЛБК
}
public class LBKCalculator {
  // вычисляет время ЛБК веребором
}
public static class SwEphCalculator {
  // работа с Swiss Ephemeris
}
public static class TimeCalculator {
  // преобразование дат
}
```

#### БД
```c#
public class DBDayInformation {
  // сохранение и получение информации
}
```
![image](https://user-images.githubusercontent.com/54811112/223130732-6b2a6a00-45bb-490e-b93f-799df3d558b8.png)

#### Model
```c#
public class ModelInformation {
  // связывает вычисления и бд, упрощая получение информации по дню
}
```

#### ViewModel
```c#
public class DayInformation {
  // содержит нужную информацию про данный день
}
```

#### View
```c#
public class DayReview {
  // возвращает пользователю информацию о дне
}
```

#### Архитектура
![image](https://user-images.githubusercontent.com/54811112/223140442-402489af-c509-4365-8e27-02b61b35be06.png)

#### Паттерны
- **Абстрактная фабрика** - AspectCalculator и LBKCalculator оба вычисляют поля для DayInformation
- **Строитель** - DayInformation состоит из множества полей, которые можно заполнять при помощи этого паттерна
- **Адаптер** - SwEphCalculator упрощает работу с Swiss Ephemeris
- **Фасад** - ModelInformation объединяет в себе доступ к бд и вычислениям
- **Стратегия** - Позволяет изменять реализацию IAspectCalculator, улучшая алгоритм или ускрояя его, но уменьшая точность
- **Посредник** - LBKCalculator может использовать AspectCalculator для поиска последнего аспекта в текущем знаке
