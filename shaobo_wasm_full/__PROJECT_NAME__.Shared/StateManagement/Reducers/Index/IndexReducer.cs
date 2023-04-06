using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fluxor;

using __PROJECT_NAME__.Shared.StateManagement.Actions.Index;
using __PROJECT_NAME__.Shared.StateManagement.Stores.Index;

namespace __PROJECT_NAME__.Shared.StateManagement.Reducers.Index;

public class IndexReducer
{
    [ReducerMethod]
    public static IndexStore ReduceIncrementCounterAction(IndexStore store, IncrementCounterAction action)
    {
        return store with { ClickCounter = store.ClickCounter + 1 };
    }

    [ReducerMethod]
    public static IndexStore ReduceSetCounterAction(IndexStore store, SetCounterAction action)
    {
        return store with { ClickCounter = action.CounterValue };
    }

    [ReducerMethod]
    public static IndexStore ReduceFetchBooksAction(IndexStore store, FetchBooksAction action)
    {
        return store with { IsLoading = true };
    }

    [ReducerMethod]
    public static IndexStore ReduceFetchBooksResultAction(IndexStore store, FetchBooksResultAction action)
    {
        return store with { IsLoading = false, books = action.books };
    }
}
