
// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

#region Style
[assembly: SuppressMessage ("Style", "IDE0007:Use implicit type", Justification = "👎🏻", Scope = "member", Target = "~M:Test.Collection.CollectionExtensionsTests.ToReadOnlyDictionary1_ProvidedWithValidCollection_ReturnsRODict(System.Nullable{System.Boolean})")]
[assembly: SuppressMessage ("Style", "IDE0007:Use implicit type", Justification = "👎🏻", Scope = "member", Target = "~M:Test.Collection.CollectionExtensionsTests.ToIList_ProvidedWithICollectionOfT_ReturnsTArray")]
[assembly: SuppressMessage ("Style", "IDE0007:Use implicit type", Justification = "👎🏻", Scope = "member", Target = "~M:Test.Collection.CollectionExtensionsTests.ToIList_ProvidedWithIEnumerableOfT_ReturnsListOfT")]
[assembly: SuppressMessage ("Style", "IDE0007:Use implicit type", Justification = "👎🏻", Scope = "member", Target = "~M:Test.Collection.CollectionExtensionsTests.ToIList_ProvidedWithIListOfT_ReturnsIListOfT")]
[assembly: SuppressMessage ("Style", "IDE0007:Use implicit type", Justification = "👎🏻", Scope = "member", Target = "~M:Test.Collection.CollectionExtensionsTests.ToIList_ProvidedWithNullExpectsEmpty_ReturnsEmptyArray")]
[assembly: SuppressMessage ("Style", "IDE0007:Use implicit type", Justification = "👎🏻", Scope = "member", Target = "~M:Test.Collection.CollectionExtensionsTests.ToReadOnlyDictionary2_ProvidedWithValidCollection_ReturnsRODict(System.Nullable{System.Boolean})")]

[assembly: SuppressMessage("Style", "IDE0034:Simplify 'default' expression", Justification = "Less obvious.", Scope = "member", Target = "~M:Test.Object.ObjectAidTests.NullableOrResult_NullProvided_ReturnsNullable")]

[assembly: SuppressMessage("Style", "IDE0039:Use local function", Justification = "False positive.", Scope = "member", Target = "~M:Test.Collection.CollectionExtensionsTests.ToReadOnlyDictionary1_ProvidedWithValidCollection_ReturnsRODict(System.Nullable{System.Boolean})")]
[assembly: SuppressMessage("Style", "IDE0039:Use local function", Justification = "False positive.", Scope = "member", Target = "~M:Test.Collection.CollectionExtensionsTests.ToReadOnlyDictionary2_ProvidedWithValidCollection_ReturnsRODict(System.Nullable{System.Boolean})")]
[assembly: SuppressMessage("Style", "IDE0039:Use local function", Justification = "False positive.", Scope = "member", Target = "~M:Test.Object.ObjectAidTests.NullOrResult_ValueProvided_ReturnsFunctionResult")]
[assembly: SuppressMessage("Style", "IDE0039:Use local function", Justification = "False positive.", Scope = "member", Target = "~M:Test.Object.ObjectAidTests.NullableOrResult_ValueProvided_ReturnsFunctionResult")]
[assembly: SuppressMessage("Style", "IDE0039:Use local function", Justification = "False positive.", Scope = "member", Target = "~M:Test.Enumerable.EnumerableExtensionsTests.ToDictionary_SomeEnumerableKeySelectorValueSelector_ReturnsDictionary")]
[assembly: SuppressMessage("Style", "IDE0039:Use local function", Justification = "False positive.", Scope = "member", Target = "~M:Test.Enumerable.EnumerableExtensionsTests.ToDictionary_SomeEnumerableKeySelector_ReturnsDictionary")]

[assembly: SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "Not this case.", Scope = "member", Target = "~T:Test.Type.TypeAideTests")]

[assembly: SuppressMessage ("Style", "IDE0045:Convert to conditional expression", Justification = "Fine.", Scope = "member", Target = "~M:Test.Collection.CollectionExtensionsTests.ToReadOnlyDictionary1_ProvidedWithValidCollection_ReturnsRODict(System.Nullable{System.Boolean})")]
[assembly: SuppressMessage ("Style", "IDE0045:Convert to conditional expression", Justification = "Fine.", Scope = "member", Target = "~M:Test.Collection.CollectionExtensionsTests.ToReadOnlyDictionary2_ProvidedWithValidCollection_ReturnsRODict(System.Nullable{System.Boolean})")]

[assembly: SuppressMessage ("Style", "IDE0061:Use expression body for local functions", Justification = "No room.", Scope = "member", Target = "~M:Test.Exception.ArgumentRangeExceptionSTests.Message___SpecialInfoHasPrecendenceOverActualValue")]
#endregion

[assembly: SuppressMessage ("Naming", "CA1716:Identifiers should not match keywords", Justification = "Fine.", Scope = "namespace", Target = "~N:Test.Object")]

[assembly: SuppressMessage("Code Quality", "IDE0051:Remove unused private members", Justification = "Not this case.", Scope = "member", Target = "~T:Test.Type.TypeAideTests")]
