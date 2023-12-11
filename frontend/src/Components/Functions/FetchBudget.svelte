<script>
  import { onMount } from "svelte";
  export let budgetList;

  onMount(async () => {
    const response = await fetch("https://tres-budget.azurewebsites.net/api/Budget");
    if (response.ok) {
      budgetList = await response.json();
      console.log(budgetList);
    } else {
      console.error("Failed to fetch budget:", response.status);
    }
  });
</script>
