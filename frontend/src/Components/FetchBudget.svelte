<script>
import { onMount } from "svelte";

onMount(async () => {
  fetch("https://localhost:7022/api/Budget")
  .then(response => response.json())
  .then(data => {
		console.log(data);
    apiData.set(data);
  }).catch(error => {
    console.log(error);
    return [];
  });
});
</script>