<script>
  import { onMount } from "svelte";
  import Expences from "./Expences.svelte";
  import Income from "./Income.svelte";
  import Accordion from "./Accordion.svelte";
  export let budget = { expenses: [], income: [] };
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

<!-- <Expences {budget} /> -->
<Income {budget} />
<Accordion {budget} />
