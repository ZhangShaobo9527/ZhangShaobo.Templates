using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fluxor;

using __PROJECT_NAME__.Shared.Models;
using __PROJECT_NAME__.Shared.StateManagement.Stores.Index;

namespace __PROJECT_NAME__.Shared.StateManagement.Features.Index;

public class IndexFeature : Feature<IndexStore>
{
    public override string GetName()
    {
        return nameof(IndexStore);
    }

    protected override IndexStore GetInitialState()
    {
        return new IndexStore(
            ClickCounter: 0,
            IsLoading: false,
            books: Array.Empty<Book>());
    }
}
