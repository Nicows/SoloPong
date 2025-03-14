using System.Collections.Generic;
using System.Linq;
using NicolasKohler.Utilities;
using UnityEngine;

/// <summary>
/// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
/// If you don't feel free to make this a standard class
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem> {

    protected override void Awake() {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources() {
        // ExampleHeroes = Resources.LoadAll<ScriptableExampleHero>("ExampleHeroes").ToList();
        // _ExampleHeroesDict = ExampleHeroes.ToDictionary(r => r.HeroType, r => r);
    }

    
}   