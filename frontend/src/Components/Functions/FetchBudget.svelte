<script>
  import { onMount } from "svelte";
  export let budgetList;
  //const tresAzureURL = "https://tres-budget.azurewebsites.net/api/Budget";
  const baseAdress =
    "https://myapi-bubycqeyg2awapd6.northeurope-01.azurewebsites.net";
  const url = "/api/Budget";
  onMount(async () => {
    try {
      const response = await fetch(baseAdress + url);
      if (response.ok) {
        budgetList = await response.json();
        console.log(budgetList);
      } else {
        console.error("Failed to fetch budget:", response.status);
      }
    } catch (error) {
      console.error("Error fetching budget:", error);
    }
  });
</script>
