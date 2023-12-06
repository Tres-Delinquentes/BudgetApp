<script lang="ts">
  import Cross from "../assets/circle-x.svg";
  import Add from "../assets/circle-plus.svg";
  import PlusIcon from "../assets/plus.svg";
  import MinusIcon from "../assets/minus.svg";
  import { GetLatestIdOfItem } from "./Functions/FetchLatestId.svelte";
  export let budget;
  let indexOf;

  $: errorResponse = null;

  async function PostBudgetToApi(budget) {
    fetch("https://localhost:7022/api/Budget", {
      method: "POST",
      body: JSON.stringify(budget),
      headers: {
        "content-Type": "application/json",
      },
    })
      .then(async (r) => {
        if (!r.ok) {
          errorResponse = await r.json();
          console.log("Error occurred:", errorResponse.message);
        } else {
          return r.json();
        }
      })
      .then((responseData) => {
        if (responseData) {
          console.log("Success:", responseData);
        }
      })
      .catch((error) => {
        console.error("Fetch error:", error);
      });
  }
</script>

<div class="content-second mt-3">
  <div class="wrapper-small">
    <div class="small-left">
      <h1>{budget.income.totalAmount}</h1>
      Lorem ipsum dolor, sit amet consectetur adipisicing elit. Necessitatibus obcaecati
      possimus sequi aliquid eveniet labore, deleniti, quas rerum sint optio nostrum,
      minima porro placeat. Minima sunt dignissimos saepe iusto aut!
    </div>
    <div class="small-right">
      Lorem ipsum dolor sit amet consectetur, adipisicing elit. Suscipit, culpa
      eum ducimus fugit, modi magnam ipsum, consequuntur officia est expedita
      quasi aliquam? Obcaecati minima sit accusantium atque omnis perferendis
      expedita?
    </div>
  </div>
  <div class="full-bleed subdisplay total-expenses"></div>
  <button on:click={() => PostBudgetToApi(budget)}>Post Budget</button>
  {#if errorResponse !== null}
    <p>{errorResponse.message}</p>
  {/if}
</div>

<style>
</style>
