# space-shooter
Top-down space shooter

Проект создан на основе вебинара от SkillBox. Изначально проект был для ПК, я переделала его на мобильный. Ниже список всего, что было переделано или добавлено, фактически, от оригинального проекта остались только ассеты. 

UI/UX. Верстка/логика:
- стартовый экран. 
- HUD игрового уровня:
- экран окончания уровня:
- иконка приложения.

Техническая часть:
- добавлено управление тач для мобильных устройств
- разделила основной геймплей, стартовый экран и экран завершения уровня на разный сцены
- музыка не прекращается при переходе из сцены в сцену
- добавлен подсчет очков

<b> самолет игрока: </b>
- реализовала систему здоровья
- реализовала беспрерывную стрельбу вместо стрельбы по нажатию кнопки
- сделала, что пули игрока могут наносить урон
- сделала получение и нанесение урона от столкновений с врагами

<b> самолеты врага: </b>
- перешла с эмиттера на спавн волнами с помощью ScriptableObject (новые волны можно менять через конфиг) 
- реализовала полет врагов по траекториям
- реализовала несколько разных врагов
- сделала врагам здоровье
- сделала пулям урон
- сделала получение и нанесение урона от столкновений с игроком.
