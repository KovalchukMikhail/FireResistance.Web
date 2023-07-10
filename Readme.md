# FireResistance
## Общая информация о ресурсе
Данный ресурс предоставляет пользователям возможность проведения расчетов по определению пределов огнестойкости железобетонных конструкций. На данный момент реализованы 3 типа расчетов:

* Проверка предела огнестойкости железобетонной колонны подверженной огневому воздействию с 4 сторон.

* Проверка предела огнестойкости безбалочной железобетонной плиты перекрытия сплошного сечения с жестким опиранием на колонны. При условии огневого воздействия снизу.

* Проверка предела огнестойкости безбалочной железобетонной плиты перекрытия сплошного сечения с жестким опиранием по двум сторонам на стены. При условии огневого воздействия снизу.

<br/>

## Тестовый аккаунт.
Для возможности сохранения расчетов и запуска сохраненных расчетов необходимо зарегестироваться на ресурсе или воспользоваться тестовым аккаунтом

логин: temp@te.mp

пароль: Temp!2345

<br/>

## Общая информация о методиках расчета огнестойкости.

Расчеты выполняются в соответствии с СП468.1325800.2019. В программе реализован алгоритм автоматического определения температуры бетона и арматуры по графикам приложений А и Б СП468.1325800.2019 "Бетонные и железобетонные конструкции. Правила обеспечения огнестойкости и огнесохранности".

<br/>

Нормативные и расчетные характеристики арматуры и бетона без учета огневого воздействия приняты в соответствии с СП 63.13330.2018 "Бетонные и железобетонные конструкции. Основные положения".

<br/>

Нормативные и расчетные характеристики арматуры и бетона с учетом огневого воздействия получены в соответствии с пунктом 5 СП468.1325800.2019 путем умножения значений характеристик материалов без учета огневого воздействия на соответствующие коэффициенты.

<br/>

Для корректного ввода исходных данных при использовании данного ресурса рекомендуется ознакомится с предпосылками расчета и расчетными методиками представленными в СП468.1325800.2019, СП 63.13330.2018 и СП 20.13330.2016.

<br/>

В соответствии с пунктом 8.7 СП468.1325800.2019 применен упрощенный метод поэлементного расчета огнестойкости железобетонных конструкций, при котором рассматривается уменьшенное поперечное сечение конструкций за вычетом толщин слоев бетона, нагретого выше критической температуры.