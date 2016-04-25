
LambdaCompare.cs

This class allows us to verify the exact lambda expression that is called on a Mock object

Verify your Mocks as per the following example:

_customerClassRepository.Verify(x => x
	.Query(It.Is<Expression<Func<CustomerClass, bool>>>(e =>
		LambdaCompare.Eq(e, y => y.Name.Equals("CustomerClass")))), Times.Once);