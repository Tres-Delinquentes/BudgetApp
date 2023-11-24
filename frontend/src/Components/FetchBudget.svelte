<script>
  import { onMount } from "svelte";
  let budget = { expenses: [], income: [] };

  onMount(async () => {
    const response = await fetch("https://localhost:7022/api/Budget");
    console.log(response);
    if (response.ok) {
      const data = await response.json();
      budget = data;
    } else {
      console.error("Failed to fetch budget:", response.status);
    }
  });
</script>

<main>
  {#each budget.expenses as expense}
    <div class="expense">
      <h3>{expense.name}</h3>
      <div class="items">
        {#each expense.items as item}
          <p>{item.name}: {item.amount}</p>
        {/each}
      </div>
    </div>
  {/each}
  {#each budget.income as income}
    <p>{income.name}: {income.amount}</p>
  {/each}
</main>
