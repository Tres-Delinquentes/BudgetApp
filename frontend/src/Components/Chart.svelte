<script>
    import { onMount, onDestroy } from "svelte";
    import Chart from "chart.js/auto";

    export let budget; 

    let chart = null; 
    let canvasElement; 

    // Fördefinierade färger
    const colors = [
        "#32a8ae", 
        "#bce8eb", 
        "#31a4aa", 
        "#dff5f6", 
        "#091e20", 
        "#51c6cd",
        "#144043", 
        "#31a4aa",
        "#091f20", 
        "#dff4f6", 
    ];

    function getColors(num) {
        return Array.from({ length: num }, (_, i) => colors[i % colors.length]);
    }

    function createChart() {
        if (chart) {
            chart.destroy();
        }

        const ctx = canvasElement.getContext("2d");
        chart = new Chart(ctx, {
            type: "bar",
            data: {
                labels: budget.expenses.map((expense) => expense.name),
                datasets: [
                    {
                        data: budget.expenses.map(
                            (expense) => expense.totalAmount,
                        ),
                        backgroundColor: getColors(budget.expenses.length),
                        borderWidth: 1,
                    },
                ],
            },
            options: {
                responsive: true,
                plugins: {
                    legend: { display: false },
                    title: {
                        display: false
                    },
                },
            },
        });
    }

    onMount(createChart);
    onDestroy(() => {
        if (chart) chart.destroy();
    });

    $: if (budget && budget.expenses && canvasElement) {
        createChart();
    }
</script>

<canvas bind:this={canvasElement}></canvas>