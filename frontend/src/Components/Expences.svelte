<script>
    export let budget;
    let currency = "SEK";
</script>

<section>
    {#each budget.expenses as expense}
        <div class="expense">
            <h3>{expense.name}</h3>
            <div class="items">
                {#each expense.items as item}
                    <div class="expence--items">
                        <input
                            class="expence-items--name"
                            type="text"
                            bind:value={item.name}
                        />
                        <input
                            class="expence-items--amount"
                            type="digit"
                            min="0"
                            bind:value={item.amount}
                        />
                        <div class="expence--currency">{currency}</div>
                    </div>
                {/each}
            </div>
        </div>
    {/each}
</section>

<style>
    .expence--items {
        display: inline-block;
        padding: 1px;
    }

    .expence-items--name {
        display: inline-block;
        width: 10rem;
        margin: 0 1rem 0 0;
    }

    .expence-items--amount {
        display: inline-block;
        width: 30px;
        margin: 0 0.5rem 0 0;
    }

    .expence--currency {
        display: inline-block;
    }
</style>
