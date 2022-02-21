using System;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {
    List<InsurancePolicy> list = new List<InsurancePolicy>();
    int choice;
    while (true){
      Console.WriteLine("1 – Create Health Insurance Policy");
      Console.WriteLine("2 – Create Term-Life Insurance Policy");
      Console.WriteLine("3 – Exit");
      choice = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine();
      if (choice == 1){
        Console.WriteLine("Enter name of policy holder:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter deductible amount:");
        double deduc = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter co-payment amount:");
        double co = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter total out-of-pocket amount: ");
        double top = Convert.ToDouble(Console.ReadLine());
        list.Add(new HealthInsurancePolicy(name, deduc, co, top));
      }
      else if (choice == 2){
        Console.WriteLine("Enter name of policy holder:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter name of beneficiary");
        string b = Console.ReadLine();
        Console.WriteLine("Enter number of years in term: ");
        int term = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter amount of payout:");
        double pay = Convert.ToDouble(Console.ReadLine());
      }
      else if (choice == 3){
        break;
      }
      else{
        Console.WriteLine("Error: Please Enter Valid Input");
      }
    }
    for (int i = 0; i < list.Count; i++){
      InsurancePolicy index = list[i];
      Console.WriteLine(index);
      Console.WriteLine();
    }
  }
  interface IDeductible {
    bool hasMetDeductible();
    bool hasMetTotalOutOfPocket();
  }
  abstract class InsurancePolicy{
    public string policyHolder;
    private int policyNumber;
    private static int numberOfPolicies = 0;
    private double premium = 0;
    public InsurancePolicy(string name) {
      policyHolder = name;
      policyNumber = numberOfPolicies++;
    }
    public void setPolicyHolder(string n){
      policyHolder = n;
    }
    public string getPolicyHolder(){
      return policyHolder;
    }
    public void setPolicyNumber(int x){
      policyNumber = x;
    }
    public int getPolicyNumber(){
      return policyNumber;
    }
    public void setPremium(double x){
      premium = x;
    }
    public double getPremium(){
      return premium;
    }
    public abstract void selectPolicyCoverage();
    public abstract void calculatePremium();
    public override string ToString(){
      return "Policy Holder: " + getPolicyHolder() + ", Policy Number: " + getPolicyNumber() + ", Premium: " + getPremium();
    }
  }
  class TermLifeInsurancePolicy : InsurancePolicy {
    private string beneficiary;
    private int term;
    private double termPayout;
    public TermLifeInsurancePolicy(string polName, string n, int t, double tP) : base(polName){
      beneficiary = n;
      term = t;
      termPayout = tP;
    }
    public string getBeneficiary(){
      return beneficiary;
    }
    public void setBeneficiary(string b){
      beneficiary = b;
    }
    public int getTerm(){
      return term;
    }
    public void setTerm(int x){
      term = x;
    }
    public double getTermPayout(){
      return termPayout;
    }
    public void setTermPayout(double d){
      termPayout = d;
    }
    public override void selectPolicyCoverage(){
      Console.WriteLine("selecting policy coverages");
    }
    public override void  calculatePremium(){
      Console.WriteLine("calculating and updating premium");
    }
    public override string ToString(){
      return base.ToString() + ", Beneficiary: " + beneficiary + ", Term: " + term + ", Term Payout: " + termPayout;
    }
  }
  
  class HealthInsurancePolicy : InsurancePolicy, IDeductible {
    private double deductibleLimit;
    private double totalDeductiblePaid = 0;
    private double coPayment;
    private double totalCoPaymentPaid;
    private double totalOutOfPocket;
    public HealthInsurancePolicy(string n, double dl, double cp, double toop) : base(n) {
      base.setPolicyHolder(n);
      deductibleLimit = dl;
      coPayment = cp;
      totalOutOfPocket = toop;
    }
    public double getDeductibleLimit(){
      return deductibleLimit;
    }
    public void setDeductibleLimit(double d){
      deductibleLimit = d;
    }
    public double getTotalDeductiblePaid(){
      return totalDeductiblePaid;
    }
    public void setTotalDeductiblePaid(double d){
      totalDeductiblePaid = d;
    }
    public double getCoPayment(){
      return coPayment;
    }
    public void setCoPayment(double d){
      coPayment = d;
    }
    public double getTotalCoPaymentPaid(){
      return totalCoPaymentPaid;
    }
    public void setTotalCoPaymentPaid(double d){
      totalCoPaymentPaid = d;
    }
    public double getTotalOutOfPocket(){
      return totalOutOfPocket;
    }
    public void setTotalOutOfPocket(double d){
      totalOutOfPocket = d;
    }
    public override void selectPolicyCoverage(){
      Console.WriteLine("selecting policy coverages");
    }
    public override void calculatePremium(){
      Console.WriteLine("calculating and updating premium");
    }
    public bool hasMetDeductible(){
      if(totalDeductiblePaid >= deductibleLimit){
        return true;
      }
      else{
        return false;
      }
    }
    public bool hasMetTotalOutOfPocket(){
      if (totalDeductiblePaid + totalCoPaymentPaid >=
      totalOutOfPocket){
        return true;
        }
      else{
        return false;
      }
    }
    public override string ToString(){
      return base.ToString() + ", Deductible Limit: " + deductibleLimit + ", Total Deductible Paid: " + totalDeductiblePaid + ", Co-Payment: " + coPayment + ", Total Co-Payment Paid: " + totalCoPaymentPaid + ", Total Out Of Pocket: " + totalOutOfPocket;
    }
  }
}