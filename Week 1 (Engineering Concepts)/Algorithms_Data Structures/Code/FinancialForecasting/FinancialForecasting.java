public class FinancialForecasting {
    static class FinancialForecast {
        public double forecast(double current, double rate, int years) {
            if (years == 0) return current;
            return forecast(current * (1 + rate), rate, years - 1);
        }

        public double forecastMemo(double current, double rate, int years, double[] memo) {
            if (years == 0) return current;
            if (memo[years] != 0) return memo[years];
            memo[years] = forecastMemo(current, rate, years - 1, memo) * (1 + rate);
            return memo[years];
        }
    }

    public static void main(String[] args) {
        FinancialForecast forecast = new FinancialForecast();

        double currentValue = 10000;
        double growthRate = 0.10; // 10% per year
        int years = 5;

        double futureValue = forecast.forecast(currentValue, growthRate, years);
        System.out.println("Predicted Value after " + years + " years (recursive): Rs." + futureValue);

        double[] memo = new double[years + 1];
        double memoValue = forecast.forecastMemo(currentValue, growthRate, years, memo);
        System.out.println("Predicted Value using Memoization: Rs." + memoValue);
    }
}
