## Unity Common Scripts
A refactoring of my previous [Unity Essential Scripts](https://github.com/epoHless/unity2d-essential-scripts) repository.

### Features
---

**Generic Object Pooler**

```csharp
public abstract class ObjectPooler<T> : MonoBehaviour where T : MonoBehaviour
```
Inheritable Generic Object Pooler that manages MonoBehaviours

---

**Health & Damage System with UI HealthBar**

a plug-n-play component that interacts with an interface `IDamageable` in order to deal damage.
