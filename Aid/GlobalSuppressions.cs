
// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

#region Style
[assembly: SuppressMessage ("Style", "IDE0021:Use expression body for constructors", Justification = "No room.", Scope = "member", Target = "~M:Software9119.Aid.Concurrency.AsyncAide.FactorySync.#ctor(System.Threading.Tasks.TaskCreationOptions,System.Threading.Tasks.TaskContinuationOptions,System.Threading.Tasks.TaskScheduler)")]
[assembly: SuppressMessage ("Style", "IDE0021:Use expression body for constructors", Justification = "No room.", Scope = "member", Target = "~M:Software9119.Aid.Concurrency.Unchecked.AsyncAide.FactorySync.#ctor(System.Threading.Tasks.TaskCreationOptions,System.Threading.Tasks.TaskContinuationOptions,System.Threading.Tasks.TaskScheduler)")]

[assembly: SuppressMessage ("Style", "IDE0022:Use expression body for methods", Justification = "No room.", Scope = "member", Target = "~M:Software9119.Aid.Enumerable.EnumerableExtensions.ToDictionary``2(System.Collections.Generic.IEnumerable{``1},System.Func{``1,``0},System.Int32)~System.Collections.Generic.Dictionary{``0,``1}")]
[assembly: SuppressMessage ("Style", "IDE0022:Use expression body for methods", Justification = "No room.", Scope = "member", Target = "~M:Software9119.Aid.Concurrency.Unchecked.AsyncAide.FactorySync.RunSync``1(System.Func{System.Threading.Tasks.Task{``0}})~``0")]
[assembly: SuppressMessage ("Style", "IDE0022:Use expression body for methods", Justification = "No room.", Scope = "member", Target = "~M:Software9119.Aid.Concurrency.Unchecked.AsyncAide.FactorySync.RunSync(System.Func{System.Threading.Tasks.Task})")]
[assembly: SuppressMessage ("Style", "IDE0022:Use expression body for methods", Justification = "No room.", Scope = "member", Target = "~M:Software9119.Aid.Collection.CollectionExtensions.ToReadOnlyCollection``1(System.Collections.Generic.IEnumerable{``0},System.Boolean)~System.Collections.ObjectModel.ReadOnlyCollection{``0}")]
[assembly: SuppressMessage ("Style", "IDE0022:Use expression body for methods", Justification = "No room.", Scope = "member", Target = "~M:Software9119.Aid.Collection.CollectionExtensions.ToReadOnlyDictionary``3(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1},System.Func{``0,``2},System.Boolean)~System.Collections.ObjectModel.ReadOnlyDictionary{``1,``2}")]
[assembly: SuppressMessage ("Style", "IDE0022:Use expression body for methods", Justification = "No room.", Scope = "member", Target = "~M:Software9119.Aid.Collection.CollectionExtensions.AsReadOnlyDictionary``2(System.Collections.Generic.Dictionary{``0,``1},System.Boolean)~System.Collections.ObjectModel.ReadOnlyDictionary{``0,``1}")]
[assembly: SuppressMessage ("Style", "IDE0022:Use expression body for methods", Justification = "No room.", Scope = "member", Target = "~M:Software9119.Aid.Collection.CollectionExtensions.ToReadOnlyDictionary``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1},System.Boolean)~System.Collections.ObjectModel.ReadOnlyDictionary{``1,``0}")]
[assembly: SuppressMessage ("Style", "IDE0022:Use expression body for methods", Justification = "No room.", Scope = "member", Target = "~M:Software9119.Aid.Concurrency.Unchecked.WaitHandleExtensions.WaitOneAsync(System.Threading.WaitHandle,System.Threading.CancellationToken,System.TimeSpan,System.Threading.Tasks.TaskScheduler)~System.Threading.Tasks.Task{System.Boolean}")]

[assembly: SuppressMessage ("Style", "IDE0045:Convert to conditional expression", Justification = "Just fine.", Scope = "member", Target = "~M:Software9119.Aid.Type.TypeAide.IsUnManaged(System.Type)~System.Boolean")]
[assembly: SuppressMessage ("Style", "IDE0045:Convert to conditional expression", Justification = "Just fine.", Scope = "member", Target = "~M:Software9119.Aid.Collection.CollectionExtensions.AsOrTo``2(System.Collections.Generic.IEnumerable{``0},System.Boolean)~``1")]

[assembly: SuppressMessage ("Style", "IDE0046:Convert to conditional expression", Justification = "Not my style.", Scope = "member", Target = "~M:Software9119.Aid.Collection.CollectionExtensions.ToIList``1(System.Collections.Generic.IEnumerable{``0},System.Boolean)~System.Collections.Generic.IList{``0}")]
[assembly: SuppressMessage ("Style", "IDE0046:Convert to conditional expression", Justification = "Just fine.", Scope = "member", Target = "~M:Software9119.Aid.Object.ObjectAide.NullOrResultCore``2(``0,System.Func{``0,``1})~System.Object")]
[assembly: SuppressMessage ("Style", "IDE0046:Convert to conditional expression", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Concurrency.AsyncAide.FactorySync.RunSync``1(System.Func{System.Threading.Tasks.Task{``0}})~``0")]
[assembly: SuppressMessage ("Style", "IDE0046:Convert to conditional expression", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Concurrency.AsyncAide.RunSync``1(System.Func{System.Threading.Tasks.Task{``0}})~``0")]
#endregion

#region Naming
[assembly: SuppressMessage ("Naming", "CA1715:Identifiers should have correct prefix", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Collection.CollectionExtensions.AsOrTo``2(System.Collections.Generic.IEnumerable{``0},System.Boolean)~``1")]
[assembly: SuppressMessage ("Naming", "CA1715:Identifiers should have correct prefix", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Collection.CollectionExtensions.AsReadOnlyDictionary``2(System.Collections.Generic.Dictionary{``0,``1},System.Boolean)~System.Collections.ObjectModel.ReadOnlyDictionary{``0,``1}")]
[assembly: SuppressMessage ("Naming", "CA1715:Identifiers should have correct prefix", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Collection.CollectionExtensions.ToReadOnlyDictionary``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1},System.Boolean)~System.Collections.ObjectModel.ReadOnlyDictionary{``1,``0}")]
[assembly: SuppressMessage ("Naming", "CA1715:Identifiers should have correct prefix", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Collection.CollectionExtensions.ToReadOnlyDictionary``3(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1},System.Func{``0,``2},System.Boolean)~System.Collections.ObjectModel.ReadOnlyDictionary{``1,``2}")]
[assembly: SuppressMessage ("Naming", "CA1715:Identifiers should have correct prefix", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Object.ObjectAide.NullableOrResult``2(``0,System.Func{``0,``1})~System.Nullable{``1}")]
[assembly: SuppressMessage ("Naming", "CA1715:Identifiers should have correct prefix", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Object.ObjectAide.NullOrResult``2(``0,System.Func{``0,``1})~``1")]
[assembly: SuppressMessage ("Naming", "CA1715:Identifiers should have correct prefix", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Enumerable.EnumerableExtensions.ToDictionary``3(System.Collections.Generic.IEnumerable{``2},System.Func{``2,``0},System.Func{``2,``1},System.Int32)~System.Collections.Generic.Dictionary{``0,``1}")]
[assembly: SuppressMessage ("Naming", "CA1715:Identifiers should have correct prefix", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Enumerable.EnumerableExtensions.ToDictionary``2(System.Collections.Generic.IEnumerable{``1},System.Func{``1,``0},System.Int32)~System.Collections.Generic.Dictionary{``0,``1}")]

[assembly: SuppressMessage ("Naming", "CA1716:Identifiers should not match keywords", Justification = "No.", Scope = "namespace", Target = "~N:Software9119.Aid.Object")]
[assembly: SuppressMessage ("Naming", "CA1716:Identifiers should not match keywords", Justification = "No.", Scope = "type", Target = "~T:Software9119.Aid.Collection.Step")]

[assembly: SuppressMessage ("Naming", "CA1721:Property names should not match get methods", Justification = "Not this case.", Scope = "type", Target = "~T:Software9119.Aid.Exception.ArgumentRangeExceptionS`1")]
[assembly: SuppressMessage ("Naming", "CA1721:Property names should not match get methods", Justification = "Not this case.", Scope = "type", Target = "~T:Software9119.Aid.Exception.ArgumentRangeExceptionC`1")]
#endregion

#region Design
[assembly: SuppressMessage ("Design", "CA1002:Do not expose generic lists", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Enumerable.EnumerableExtensions.ToList``1(System.Collections.Generic.IEnumerable{``0},System.Int32)~System.Collections.Generic.List{``0}")]

[assembly: SuppressMessage ("Design", "CA1034:Nested types should not be visible", Justification = "Fine.", Scope = "type", Target = "~T:Software9119.Aid.Concurrency.AsyncAide.FactorySync")]
[assembly: SuppressMessage ("Design", "CA1034:Nested types should not be visible", Justification = "Fine.", Scope = "type", Target = "~T:Software9119.Aid.Concurrency.Unchecked.AsyncAide.FactorySync")]

[assembly: SuppressMessage ("Design", "CA1051:Do not declare visible instance fields", Justification = "Fine.", Scope = "member", Target = "~F:Software9119.Aid.Collection.Step.Size")]

[assembly: SuppressMessage ("Design", "CA1062:Validate arguments of public methods", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Enumerable.EnumerableExtensions.ToArray``1(System.Collections.Generic.IEnumerable{``0},System.Int32)~``0[]")]
[assembly: SuppressMessage ("Design", "CA1062:Validate arguments of public methods", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Enumerable.EnumerableExtensions.ToList``1(System.Collections.Generic.IEnumerable{``0},System.Int32)~System.Collections.Generic.List{``0}")]
[assembly: SuppressMessage ("Design", "CA1062:Validate arguments of public methods", Justification = "Fine.", Scope = "member", Target = "~M:Software9119.Aid.Enumerable.EnumerableExtensions.ToDictionary``3(System.Collections.Generic.IEnumerable{``2},System.Func{``2,``0},System.Func{``2,``1},System.Int32)~System.Collections.Generic.Dictionary{``0,``1}")]

[assembly: SuppressMessage ("Design", "CA1068:CancellationToken parameters must come last", Justification = "Fine.", Scope = "type", Target = "~T:Software9119.Aid.Concurrency.Unchecked.WaitHandleExtensions")]
[assembly: SuppressMessage ("Design", "CA1068:CancellationToken parameters must come last", Justification = "Fine.", Scope = "type", Target = "~T:Software9119.Aid.Concurrency.WaitHandleExtensions")]
#endregion