# Система инвентаря для Unity

Проект представляет собой базовую систему инвентаря с поддержкой перетаскивания (drag-and-drop) для Unity, подходящую для интеграции в 2D-игры и 3D-игры.

## Компоненты

Система состоит из следующих скриптов:

*   **`DemoScript.cs`:** Простой демонстрационный скрипт, который показывает, как взаимодействовать с системой инвентаря (подбор, получение и использование предметов).
*   **`InventoryItem.cs`:** Представляет собой один предмет в слоте инвентаря. Обрабатывает функциональность перетаскивания.
*   **`Item.cs`:** Scriptable Object, который определяет свойства предмета (тип, спрайт, возможность стекирования и т. д.).
*   **`InventoryManager.cs`:** Управляет слотами инвентаря, обрабатывает добавление и удаление предметов, а также предоставляет доступ к текущему выбранному предмету.
*   **`InventorySlot.cs`:** Представляет собой один слот в инвентаре. Обрабатывает помещение предметов в слот и обмен предметами.

## Как использовать

1.  **Создание предметов:** Создайте новые Scriptable Objects `Item` в вашем проекте (щелкните правой кнопкой мыши в окне Project -> Create -> ScriptableObjects -> Item). Определите свойства предмета в инспекторе.
2.  **Создание UI инвентаря:**
    *   Создайте Canvas в вашей сцене.
    *   Создайте дочерние объекты GameObject под Canvas, чтобы представить слоты инвентаря. Прикрепите компонент `InventorySlot` к каждому слоту. Добавьте компонент `Image` в качестве дочернего элемента каждого слота.
    *   Создайте префаб для ваших предметов инвентаря. Этот префаб должен иметь компонент `Image`, компонент `TextMeshProUGUI` (для отображения количества в стеке) и компонент `InventoryItem`.
3.  **Настройка Inventory Manager:**
    *   Создайте пустой GameObject в вашей сцене (например, "InventoryManager").
    *   Прикрепите скрипт `InventoryManager` к этому GameObject.
    *   В инспекторе назначьте ваши игровые объекты слотов инвентаря массиву `Inventory Slots`.
    *   Назначьте префаб предмета инвентаря полю `Inventory Item Prefab`.
4.  **Настройка Demo Script (необязательно):**
    * Создайте новый GameObject (например, "Demo").
    * Прикрепите DemoScript.
    * Создайте массив и заполните его Scriptable Objects предметов, которые вы хотите иметь возможность подбирать.
    * Прикрепите игровой объект `InventoryManager` к переменной `inventoryManager` и массив Scriptable Objects предметов к переменной `itemsToPickup`.
5.  **Взаимодействие с инвентарем:**
    *   Используйте `InventoryManager.Instance.AddItem(item)` для добавления предмета в инвентарь.
    *   Используйте `InventoryManager.Instance.GetSelectedItem(bool consume)`, чтобы получить текущий выбранный предмет. Установите `consume` в `true`, чтобы удалить один экземпляр предмета из инвентаря.
    *   Выбранный слот можно изменить, нажав цифровые клавиши (1-9).