<script>
    export let budget;
    let currency = "SEK";
</script>

<section>
    {#each budget.income as income}
        <p>{income.name}: {income.amount}</p>
    {/each}
</section>
