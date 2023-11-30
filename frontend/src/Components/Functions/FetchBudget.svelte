<script>
  import { onMount } from "svelte";
  export let budget = { expenses: [], income: [] };

  onMount(async () => {
    const response = await fetch("https://localhost:7022/api/Budget");
    console.log(response);
    if (response.ok) {
      budget = await response.json();
    } else {
      console.error("Failed to fetch budget:", response.status);
    }
  });

</script>


<!-- <main class="wrapper">
  <div>
    <Accordion {budget} />
  </div>
</main> -->
