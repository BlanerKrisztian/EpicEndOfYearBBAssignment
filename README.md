# Feladat: Bevásárlókosár — Unit tesztelés & Git

## Áttekintés

Egy részben elkészített C# solution-t kapsz.  
Az osztályok és metódus-szignatúrák adottak, de **a logika nincs implementálva**.  
A feladatod: teszteket írni, implementálni a logikát, és a munkát Git-ben követni.

---

## Fontos szabályok (olvasd el implementáció előtt!)

- `AddItem()` — ha az item neve már szerepel a kosárban (kis-nagybetű független), **ne új item-et hozz létre, hanem növeld a mennyiséget**.
- `GetTotal()` — minden item `UnitPrice × Quantity` összege.
- `ApplyFixed()` — az eredmény **soha nem lehet negatív**; ha a kedvezmény nagyobb a totálnál, 0-t adj vissza.

---

## Projektstruktúra

```
├── ShoppingCartApp/                 ← Console projekt (ezt implementálod)
│   ├── CartItem.cs
│   ├── ShoppingCart.cs
│   ├── Discount.cs
│   └── Program.cs
├─ ShoppingCartAppTests/           ← MSTest projekt (ezt bővíted)
    └── Tests.cs
```

---

## Lépések

### 1. lépés — Klónozás és megnyitás

Hozz létre egy repót klónozd le és rakd bele a kibontott zip fájljait (ez a readme jelenjen majd meg a githubon), és nyisd meg a `.sln` fájlt Visual Studio 2022-ben.

### 2. lépés — Futtasd a teszteket (mind el kell, hogy bukjon)

Nyisd meg a **Test Explorer**-t és futtass minden tesztet.  
📸 **Készíts képernyőképet a bukó tesztekről.** Ez lesz a „before" képed.
A kép is kerüljön bele a repóba a saját névvel ellátva
Példa: kovacs_bela_test_before.png

### 3. lépés — Bővítsd a teszteket

Minden tesztmetódus alatt `// TODO` kommentek jelzik, milyen eseteket kell még lefedned.  
Írj új tesztmetódusokat az edge case-ekre, mielőtt bármit implementálsz.

**Minden metódus (vagy kis csoport) után commitolj:**

```
git add .
git commit -m "Edge case tesztek hozzáadva implementáció előtt"
```

(vagy a visual studio-ban a grafikus felületen)

### 4. lépés — Implementáld az osztályokat

Javasolt sorrend:

1. `CartItem` konstruktor, `GetLineTotal`, `UpdateQuantity`
2. `ShoppingCart.AddItem`, `GetItemCount`, `GetTotal`
3. `ShoppingCart.RemoveItem`, `Clear`, `GetItems`
4. `Discount` összes metódusa

**Minden metódus (vagy kis csoport) után commitolj:**

```
git commit -m "CartItem implementálva"
```

(vagy a visual studio-ban a grafikus felületen)

### 5. lépés — Minden teszt zöld

📸 **Készíts képernyőképet az összes átmenő tesztről.** Ez lesz az „after" képed.

Ez a kép is kerüljön bele a repóba a saját névvel ellátva

Példa: kovacs_bela_test_after.png

---
