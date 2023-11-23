<script>
  import { onMount } from "svelte";
  let data2;
  let budget;
  let rent;

  onMount(async () => {
    const response = await fetch("https://localhost:7022/api/Budget");
    console.log(response);
    const data = await response.json();
    budget = data;
    console.log(budget);
    console.log(budget.expenses[0].items[0].name);
    rent = budget.expenses.map((x) => x.name);
    console.log(rent);
  });
</script>

<main>
  <p>{rent}</p>
</main>
