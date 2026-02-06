# Pepsi Man Runner (Unity 3D)

یک بازی **Runner سه‌لاین** ساده ساخته‌شده با Unity برای تمرین مفاهیم پایه: حرکت رو به جلو، جابه‌جایی بین لاین‌ها، اسپاون تصادفی موانع، سیستم امتیازدهی و مدیریت Game Over.

## ویژگی‌ها

- **حرکت خودکار بازیکن** رو به جلو
- **۳ لاین ثابت** (چپ، وسط، راست) با جابه‌جایی نرم (Lerp)
- **اسپاون تصادفی موانع** با فاصله‌ی حدودی ۳ تا ۷ متر
- **برخورد با Trigger** و پایان بازی (Game Over)
- **امتیاز لحظه‌ای + بهترین رکورد** (ذخیره با `PlayerPrefs`)
- **پنل Game Over** و دکمه Restart

## کنترل‌ها

- **جابجایی لاین**: `A / D` یا `Left / Right Arrow`

## پیش‌نیازها

- **Unity**: نسخه `6000.2.10f1` (یا نزدیک به آن)

## اجرا (Play)

1. پروژه را در Unity باز کنید.
2. صحنه `Assets/Scenes/Main.unity` را باز کنید.
3. دکمه **Play** را بزنید.

- **Tag مانع‌ها**: روی Prefab مانع باید Tag با نام `Obstacle` ست شده باشد (برخورد بازیکن با همین Tag تشخیص داده می‌شود).
- **Collider**: برای مانع‌ها Collider با گزینه **Is Trigger** فعال باشد.
- **Score UI**: اگر از TextMeshPro استفاده می‌کنید، فیلدهای `scoreText` و `bestText` را در `ScoreManager` وصل کنید. اگر نه، فیلدهای Legacy (`UnityEngine.UI.Text`) را وصل کنید.

## ساختار پروژه

- `Assets/Scripts/`: اسکریپت‌های اصلی (Player، Spawner، Score، UI، GameManager)
- `Assets/Scenes/`: صحنه‌ها (از جمله `Main.unity`)
- `Assets/Prefabs/`: Prefabها (در صورت ساخت در ادیتور)
- `Assets/Materials/`: متریال‌ها
- `Docs/`: مستندات/گزارش (در صورت وجود)

## اسکریپت‌های کلیدی

- `PlayerController`: حرکت رو به جلو + تغییر لاین و تشخیص برخورد
- `ObstacleSpawner`: ساخت موانع در یکی از ۳ لاین با فاصله‌ی تصادفی
- `ScoreManager`: محاسبه امتیاز و ذخیره رکورد
- `UIManager`: نمایش/پنهان‌سازی پنل Game Over و Restart
- `GameManager`: مدیریت وضعیت بازی، توقف زمان، Restart
